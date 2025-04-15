using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Core.Features.AppUsers.Commands.Handlers
{
    public class AppUserCommandHandler : ResponseHandler,
                                            IRequestHandler<AddAppUserCommand, Response<string>>
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AppUserCommandHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddAppUserCommand request, CancellationToken cancellationToken)
        {
            //if email exist 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return BadRequest<string>("Email is used");

            var UserMapping = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(UserMapping, request.Password);

            if (!result.Succeeded) return BadRequest<string>($"Faild To Add User : {result.Errors.FirstOrDefault().ToString()}");

            await _userManager.AddToRoleAsync(UserMapping, "User");

            return Created("");
        }


        #endregion

    }
}
