using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authentication.Queries.Models;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Authentication.Queries.Handles
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                                    IRequestHandler<AuthorizeUserQuery, Response<string>>,
                                                    IRequestHandler<ConfirmEmailQuery, Response<string>>
    {

        #region Fields
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructors
        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {

            _authenticationService = authenticationService;
        }


        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>("Token Is Expired");
        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);

            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("An error occurred while confirming the email.");

            return Success<string>("Email confirmed successfully.");

        }

        #endregion
    }
}
