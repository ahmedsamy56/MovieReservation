using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Movies.Commands.Models;
using MovieReservation.Data.Entities;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Movies.Commands.Handlers
{
    public class MovieCommandHandler : ResponseHandler,
                                          IRequestHandler<AddMovieCommand, Response<string>>,
                                          IRequestHandler<EditMovieCommand, Response<string>>,
                                          IRequestHandler<DeleteMovieCommand, Response<string>>
    {
        #region Fields
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public MovieCommandHandler(IMovieService movieService, IMapper mapper)
        {
            _mapper = mapper;
            _movieService = movieService;
        }

        #endregion

        #region Functions

        public async Task<Response<string>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            //mapping 
            var MovieMapping = _mapper.Map<Movie>(request);

            //create 
            var result = await _movieService.AddMovieAsync(MovieMapping, request.posterfile);

            //return response
            switch (result)
            {
                case "NoImage":
                    return BadRequest<string>("No image was provided. Please upload an image.");

                case "FailedToUploadImage":
                    return BadRequest<string>("Image upload failed. Please try again.");

                case "FailedAdd":
                    return BadRequest<string>("Unable to add the movie. Please check your details and try again.");

                case "Success":
                    return Created<string>("The movie Added successfully.");

                default:
                    return BadRequest<string>("An unexpected error occurred. Please try again.");
            }


        }

        public async Task<Response<string>> Handle(EditMovieCommand request, CancellationToken cancellationToken)
        {
            //Check if Exist
            var movie = await _movieService.MovieExistAsync(request.Id);
            //return NotFound
            if (!movie) return NotFound<string>("Movie NotFound");
            //mapping
            var MovieMapping = _mapper.Map<Movie>(request);
            //Edit service
            var result = await _movieService.EditMovieAsync(MovieMapping, request.posterfile);
            //return response
            switch (result)
            {
                case "NoImage":
                    return BadRequest<string>("No image was provided. Please upload an image.");

                case "FailedToUploadImage":
                    return BadRequest<string>("Image upload failed. Please try again.");

                case "FailedToDeleteImage":
                    return BadRequest<string>("Delete old Image failed. Please try again.");

                case "FailedUpdate":
                    return BadRequest<string>("Unable to add the movie. Please check your details and try again.");

                case "Success":
                    return Success<string>("The movie updated successfully.");

                default:
                    return BadRequest<string>("An unexpected error occurred. Please try again.");
            }

        }

        public async Task<Response<string>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            //get movie 
            var movie = await _movieService.GetSingleMovieByIdAsync(request.Id);
            //if not exist
            if (movie == null) return NotFound<string>("Movie NotFound");
            //Delete 
            var DeleteMoive = await _movieService.DeleteMovieAsync(movie);
            //return 
            if (DeleteMoive == "Success") return Deleted<string>();
            else if (DeleteMoive == "FailedToDeleteImage") return BadRequest<string>("Delete Image failed. Please try again.");
            else return BadRequest<string>("An unexpected error occurred. Please try again.");
        }
        #endregion

    }
}
