using MovieReservation.Core.Features.Reservations.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Reservations
{
    public partial class ReservationProfile
    {
        public void GetReservationPaginatedListMapping()
        {
            CreateMap<Reservation, GetReservationPaginatedListResponse>()
                        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.Name))
                        .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Showtime.Movie.Title))
                        .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Showtime.Theater.Name))
                        .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Showtime.StartTime))
                        .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Showtime.Price));
        }

    }

}
