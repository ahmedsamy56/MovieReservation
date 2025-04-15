using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authorization.Queries.Models;
using MovieReservation.Core.Features.Authorization.Queries.Results;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Authorization.Queries.Handlers
{
    public class AuthorizationQueryHandler : ResponseHandler,
                                                            IRequestHandler<GetAllAdminsQuery, Response<List<GetAllAdminsResponse>>>


    {

        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        #endregion


        #region Constructors
        public AuthorizationQueryHandler(IAuthorizationService authorizationService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        #endregion


        #region Functions
        public async Task<Response<List<GetAllAdminsResponse>>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await _authorizationService.GetAllAdminsAsync();

            var adminsMapping = _mapper.Map<List<GetAllAdminsResponse>>(admins);

            return Success(adminsMapping);

        }


        #endregion

    }
}
