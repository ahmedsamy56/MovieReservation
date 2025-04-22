using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authorization.Commands.Models;
using MovieReservation.Service.Abstracts;
using Serilog;

namespace MovieReservation.Core.Features.Authorization.Commands.Handlers
{
    public class AuthorizationCommandHandler : ResponseHandler,
                                               IRequestHandler<AddUserToAdminRoleCommand, Response<string>>,
                                               IRequestHandler<RemoveUserFromAdminRoleCommand, Response<string>>

    {

        #region Fields
        private readonly IAuthorizationService _authorizationService;

        #endregion


        #region Constructors
        public AuthorizationCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        #endregion

        #region Functions

        public async Task<Response<string>> Handle(AddUserToAdminRoleCommand request, CancellationToken cancellationToken)
        {
            var resultMessage = await _authorizationService.AddAdminRole(request.UserId);

            if (resultMessage == "User added to Admin role.")
            {
                Log.Information("User promoted to Admin role. UserId: {UserId}", request.UserId);
                return Success(resultMessage);
            }

            Log.Warning("Failed to add Admin role. UserId: {UserId}, Reason: {Reason}", request.UserId, resultMessage);
            return BadRequest<string>(resultMessage);
        }

        public async Task<Response<string>> Handle(RemoveUserFromAdminRoleCommand request, CancellationToken cancellationToken)
        {
            var resultMessage = await _authorizationService.RemoveAdminRole(request.UserId);

            if (resultMessage == "User removed from Admin role.")
            {
                Log.Information("Admin role removed from user. UserId: {UserId}", request.UserId);
                return Success(resultMessage);
            }

            Log.Warning("Failed to remove Admin role. UserId: {UserId}, Reason: {Reason}", request.UserId, resultMessage);
            return BadRequest<string>(resultMessage);

        }

        #endregion
    }
}
