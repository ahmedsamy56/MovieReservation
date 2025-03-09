using MovieReservation.Core.Features.Theaters.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Theaters
{
    public partial class TheaterProfile
    {

        public void EditTheaterCommandMapping()
        {
            CreateMap<EditTheaterCommand, Theater>();
        }
    }
}
