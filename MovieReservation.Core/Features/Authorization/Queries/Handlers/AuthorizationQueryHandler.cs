using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authorization.Queries.Models;
using MovieReservation.Core.Features.Authorization.Queries.Results;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Results;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandler : ResponseHandler,
                                                            IRequestHandler<GetAllAdminsQuery, Response<List<GetAllAdminsResponse>>>,
                                                            IRequestHandler<GetUserRoleQuery, Response<GetUserRoleRespons>>


    {

        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<AppUser> _userManager;
        #endregion


        #region Constructors
        public AuthorizationQueryHandler(IAuthorizationService authorizationService, IMapper mapper, ICurrentUserService currentUserService, UserManager<AppUser> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }
        #endregion


        #region Functions
        public async Task<Response<List<GetAllAdminsResponse>>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await _authorizationService.GetAllAdminsAsync();

            var adminsMapping = _mapper.Map<List<GetAllAdminsResponse>>(admins);

            return Success(adminsMapping);

        }

        public async Task<Response<GetUserRoleRespons>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userId.ToString());
            if (user == null) return NotFound<GetUserRoleRespons>("User NotFound ");
            var result = await _authorizationService.GetUserRolesAsync(user);
            return Success(result);
        }


        #endregion

    }
}
