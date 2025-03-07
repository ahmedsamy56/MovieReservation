using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Movies.Commands.Models
{
    public class AddMovieCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public int SuitableAge { get; set; }
        public DateOnly releaseDate { get; set; }
        public int CategoryNumber { get; set; }

        [FromForm]
        public IFormFile? posterfile { get; set; }
    }
}
