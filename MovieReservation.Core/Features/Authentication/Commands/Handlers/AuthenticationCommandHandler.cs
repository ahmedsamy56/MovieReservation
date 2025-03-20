using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authentication.Commands.Models;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                                IRequestHandler<SignInCommand, Response<JwtResult>>,
                                                IRequestHandler<RefreshTokenCommand, Response<JwtResult>>
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructors
        public AuthenticationCommandHandler(UserManager<AppUser> userManager,
                                            SignInManager<AppUser> signInManager,
                                            IAuthenticationService authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }
        #endregion

        #region Functions
        public async Task<Response<JwtResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return BadRequest<JwtResult>("Email or password is wrong.");


            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!signInResult.Succeeded) return BadRequest<JwtResult>("Email or password is wrong.");

            var result = await _authenticationService.GetJWTToken(user);
            return Success(result);
        }

        public async Task<Response<JwtResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);
            var userIdAndExpireDate = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userIdAndExpireDate)
            {
                case ("AlgorithmIsWrong", null): return Unauthorized<JwtResult>("Algorithm Is Wrong");
                case ("TokenIsNotExpired", null): return Unauthorized<JwtResult>("Token Is Not Expired");
                case ("RefreshTokenIsNotFound", null): return Unauthorized<JwtResult>("Refresh Token Is NotFound");
                case ("RefreshTokenIsExpired", null): return Unauthorized<JwtResult>("Refresh Token Is Expired");
            }
            var (userId, expiryDate) = userIdAndExpireDate;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtResult>();
            }
            var result = await _authenticationService.GetRefreshToken(user, jwtToken, expiryDate, request.RefreshToken);
            return Success(result);
        }

        #endregion
    }
}
