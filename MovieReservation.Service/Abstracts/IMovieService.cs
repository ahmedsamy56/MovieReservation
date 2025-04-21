using Microsoft.AspNetCore.Http;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;

namespace MovieReservation.Service.Abstracts
{
    public interface IMovieService
    {
        public Task<string> AddMovieAsync(Movie movie, IFormFile file);
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<Movie> GetSingleMovieByIdAsync(int id);
        public Task<string> EditMovieAsync(Movie movie, IFormFile? file);
        public Task<bool> MovieExistAsync(int id);
        public IQueryable<Movie> FilterMoviePaginatedQuerable(MovieOrderingEnum orderingEnum, string search);
        public Task<string> DeleteMovieAsync(Movie movie);
        public Task<int> GetMoviesCountAsync();

    }
}
