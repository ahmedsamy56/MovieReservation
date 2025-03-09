using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Theaters.Queries.Models;
using MovieReservation.Core.Features.Theaters.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Theaters.Queries.Handlers
{
    public class TheaterQueryHandler : ResponseHandler,
                                                        IRequestHandler<GetTheaterByIdQuery, Response<GetTheaterByIdResponse>>,
                                                        IRequestHandler<GetTheaterPaginatedListQuery, PaginatedResult<GetTheaterPaginatedListResponse>>
    {

        #region Fields
        private readonly ITheaterService _TheaterService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public TheaterQueryHandler(ITheaterService TheaterService, IMapper mapper)
        {
            _TheaterService = TheaterService;
            _mapper = mapper;
        }

        #endregion

        #region Functions
        public async Task<Response<GetTheaterByIdResponse>> Handle(GetTheaterByIdQuery request, CancellationToken cancellationToken)
        {
            //Get data 
            var theater = await _TheaterService.GetTheaterByIdWithIncludeAsync(request.Id);
            //if not Exist 
            if (theater == null) return NotFound<GetTheaterByIdResponse>();

            //mapping 
            var TheaterMapping = _mapper.Map<GetTheaterByIdResponse>(theater);

            //return
            return Success(TheaterMapping);
        }

        public async Task<PaginatedResult<GetTheaterPaginatedListResponse>> Handle(GetTheaterPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //get Data
            var FilterQuery = _TheaterService.FilterTheaterPaginatedQuerable(request.orderingEnum, request.Search);
            //mapping
            var PaginatedListMapping = await _mapper.ProjectTo<GetTheaterPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //Add Meta data
            PaginatedListMapping.Meta = new { Count = PaginatedListMapping.Data.Count() };
            //return
            return PaginatedListMapping;
        }




        #endregion
    }
}
