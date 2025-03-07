using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class MovieService : IMovieService
    {
        #region Fields
        private readonly IMovieRepository _movieRepository;
        private readonly IFileService _fileService;

        #endregion

        #region Constructors
        public MovieService(IMovieRepository movieRepository, IFileService fileService)
        {
            _movieRepository = movieRepository;
            _fileService = fileService;
        }

        #endregion


        #region Functions
        public async Task<string> AddMovieAsync(Movie movie, IFormFile file)
        {
            var posterurl = await _fileService.UploadImageAsync("Movies", file);
            switch (posterurl)
            {
                case "NoImage":
                    return "NoImage";
                case "FailedToUploadImage":
                    return "FailedToUploadImage";
            }
            movie.Poster = posterurl;
            try
            {
                await _movieRepository.AddAsync(movie);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedAdd";
            }
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetTableNoTracking().Include(x => x.Category).Where(x => x.Id == id).FirstOrDefaultAsync();
            return movie;
        }


        public async Task<string> EditMovieAsync(Movie movie, IFormFile? file)
        {
            var DbMovie = await _movieRepository.GetByIdAsync(movie.Id);
            if (file == null)
            {
                //try use old Image
                if (_fileService.ImageExists(DbMovie.Poster))
                    movie.Poster = DbMovie.Poster;
                else
                    return "NoImage";
            }
            else
            {


            }

            try
            {
                await _movieRepository.UpdateAsync(movie);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedUpdate";
            }
        }

        public async Task<bool> MovieExistAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie != null;
        }

        public IQueryable<Movie> FilterMoviePaginatedQuerable(MovieOrderingEnum orderingEnum, string search)
        {
            var querable = _movieRepository.GetTableNoTracking().Include(x => x.Category).AsQueryable();
            if (search != null)
                querable = querable.Where(x => x.Title.Contains(search) || x.Description.Contains(search));

            switch (orderingEnum)
            {
                case MovieOrderingEnum.id:
                    querable = querable.OrderBy(x => x.Id);
                    break;
                case MovieOrderingEnum.Title:
                    querable = querable.OrderBy(x => x.Title);
                    break;
                case MovieOrderingEnum.CategoryId:
                    querable = querable.OrderBy(x => x.CategoryId);
                    break;
                case MovieOrderingEnum.releaseDate:
                    querable = querable.OrderBy(x => x.releaseDate);
                    break;
                case MovieOrderingEnum.SuitableAge:
                    querable = querable.OrderBy(x => x.SuitableAge);
                    break;
                default:
                    querable = querable.OrderBy(x => x.CreatedAt);
                    break;
            }
            return querable;
        }

        public async Task<string> DeleteMovieAsync(Movie movie)
        {
            var DeletePoster = _fileService.DeleteImage(movie.Poster);
            if (DeletePoster == "FailedToDeleteImage") return "FailedToDeleteImage";

            await _movieRepository.DeleteAsync(movie);
            return "Success";
        }

        public async Task<Movie> GetSingleMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie;
        }

        #endregion
    }
}
