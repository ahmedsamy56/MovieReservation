using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Movies.Queries.Models;
using MovieReservation.Core.Features.Movies.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Movies.Queries.Handlers
{
    public class MovieQueryHandler : ResponseHandler,
                                                IRequestHandler<GetMovieByIdQuery, Response<GetMovieByIdResponse>>,
                                                IRequestHandler<GetMoviesPaginatedListQuery, PaginatedResult<GetMoviesPaginatedListResponse>>
    {
        #region Fields
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        #endregion


        #region Constructors
        public MovieQueryHandler(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        #endregion


        #region Functions
        public async Task<Response<GetMovieByIdResponse>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            //Get data
            var Movie = await _movieService.GetMovieByIdAsync(request.Id);
            //if not Exist
            if (Movie == null)
                return NotFound<GetMovieByIdResponse>();

            //Mapping 
            var MovieMapping = _mapper.Map<GetMovieByIdResponse>(Movie);

            //Return
            return Success(MovieMapping);
        }

        public async Task<PaginatedResult<GetMoviesPaginatedListResponse>> Handle(GetMoviesPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = _movieService.FilterMoviePaginatedQuerable(request.orderingEnum, request.Search);
            var PaginatedListMapping = await _mapper.ProjectTo<GetMoviesPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedListMapping.Meta = new { Count = PaginatedListMapping.Data.Count() };
            return PaginatedListMapping;
        }

        #endregion

    }
}
