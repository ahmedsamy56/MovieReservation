using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Showtimes.Queries.Models;
using MovieReservation.Core.Features.Showtimes.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Showtimes.Queries.Handlers
{
    public class ShowtimeQueryHandler : ResponseHandler,
                                                    IRequestHandler<GetShowtimePaginatedListQuery, PaginatedResult<GetShowtimePaginatedListResponse>>,
                                                    IRequestHandler<GetShowtimeByIdQuery, Response<GetShowtimeByIdResponse>>
    {
        #region Fields
        private readonly IShowtimeService _showtimeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ShowtimeQueryHandler(IShowtimeService showtimeService, IMapper mapper)
        {
            _showtimeService = showtimeService;
            _mapper = mapper;
        }

        #endregion

        #region Functions
        public async Task<PaginatedResult<GetShowtimePaginatedListResponse>> Handle(GetShowtimePaginatedListQuery request, CancellationToken cancellationToken)
        {
            //get Data
            var FilterQuery = _showtimeService.FilterShowtimePaginatedQuerable(request.orderingEnum, request.Search, request.startDate, request.endDate);
            //mapping
            var PaginatedListMapping = await _mapper.ProjectTo<GetShowtimePaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //Add Meta data
            PaginatedListMapping.Meta = new { Count = PaginatedListMapping.Data.Count() };
            //return
            return PaginatedListMapping;
        }

        public async Task<Response<GetShowtimeByIdResponse>> Handle(GetShowtimeByIdQuery request, CancellationToken cancellationToken)
        {
            //Get data 
            var showtime = await _showtimeService.GetShowtimeByIdWithIncludeAsync(request.Id);
            //if not Exist 
            if (showtime == null) return NotFound<GetShowtimeByIdResponse>();
            //mapping 
            var showtimeMapping = _mapper.Map<GetShowtimeByIdResponse>(showtime);
            //return
            return Success(showtimeMapping);
        }


        #endregion
    }
}
