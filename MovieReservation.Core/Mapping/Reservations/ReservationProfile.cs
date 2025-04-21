using AutoMapper;

namespace MovieReservation.Core.Mapping.Reservations
{
    public partial class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            AddReservationCommandMapping();
            GetReservationPaginatedListMapping();
        }
    }
}
