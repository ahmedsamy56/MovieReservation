using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.AppUsers.Commands.Handlers
{
    public class AppUserCommandHandler : ResponseHandler,
                                            IRequestHandler<AddAppUserCommand, Response<string>>,
                                            IRequestHandler<EditAppUserCommand, Response<string>>,
                                            IRequestHandler<DeleteAppUserCommand, Response<string>>,
                                            IRequestHandler<ChangeAppUserPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AppUserCommandHandler(IMapper mapper, UserManager<AppUser> userManager, ICurrentUserService currentUserService, IAppUserService appUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _appUserService = appUserService;
        }
        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddAppUserCommand request, CancellationToken cancellationToken)
        {
            var UserMapping = _mapper.Map<AppUser>(request);
            var createResult = await _appUserService.AddUserAsync(UserMapping, request.Password);

            switch (createResult)
            {
                case "EmailIsExist":
                    return BadRequest<string>("This email is already in use.");

                case "Failed":
                    return BadRequest<string>("Registration failed. Please try again.");

                case "Success":
                    return Success<string>("");

                default:
                    return BadRequest<string>(createResult);
            }

        }

        public async Task<Response<string>> Handle(EditAppUserCommand request, CancellationToken cancellationToken)
        {
            var UserId = _currentUserService.GetUserId();
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(UserId.ToString());
            if (oldUser == null) return Unauthorized<string>();

            //Mapping
            var newUser = _mapper.Map(request, oldUser);
            newUser.Id = UserId;

            //if username is Exist
            var userByEmail = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email && x.Id != newUser.Id);
            if (userByEmail != null) return BadRequest<string>("Email is already used");

            //update
            var result = await _userManager.UpdateAsync(newUser);

            //result is not success
            if (!result.Succeeded) return BadRequest<string>("Update Failed");
            //message
            return Success("Update Successfully");

        }

        public async Task<Response<string>> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var UserId = _currentUserService.GetUserId();
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(UserId.ToString());
            if (oldUser == null) return Unauthorized<string>();

            var result = await _userManager.DeleteAsync(oldUser);

            if (!result.Succeeded) return BadRequest<string>("Deleted Failed");
            return Success("Deleted Successfully");
        }

        public async Task<Response<string>> Handle(ChangeAppUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var UserId = _currentUserService.GetUserId();
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(UserId.ToString());
            if (oldUser == null) return Unauthorized<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(oldUser, request.CurrentPassword, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success("Password Changed Successfully");
        }


        #endregion

    }
}
