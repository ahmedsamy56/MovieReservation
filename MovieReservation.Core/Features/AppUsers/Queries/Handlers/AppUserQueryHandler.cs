using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.AppUsers.Queries.Models;
using MovieReservation.Core.Features.AppUsers.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Core.Features.AppUsers.Queries.Handlers
{
    public class AppUserQueryHandler : ResponseHandler,
                                                    IRequestHandler<GetAppUserPaginationQuery, PaginatedResult<GetAppUserPaginationReponse>>,
                                                    IRequestHandler<GetAppUserByIdQuery, Response<GetAppUserByIdResponse>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        #endregion


        #region Constructors
        public AppUserQueryHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Functions
        public async Task<PaginatedResult<GetAppUserPaginationReponse>> Handle(GetAppUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetAppUserPaginationReponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetAppUserByIdResponse>> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<GetAppUserByIdResponse>("User NotFound");
            var result = _mapper.Map<GetAppUserByIdResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
