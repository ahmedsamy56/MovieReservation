using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class TheaterService : ITheaterService
    {
        #region Fields
        private readonly ITheaterRepository _theaterRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        #endregion

        #region Constructors
        public TheaterService(ITheaterRepository theaterRepository, IShowtimeRepository showtimeRepository)
        {
            _theaterRepository = theaterRepository;
            _showtimeRepository = showtimeRepository;
        }

        #endregion


        #region Functions

        public async Task<string> AddTheaterAsync(Theater theater)
        {
            await _theaterRepository.AddAsync(theater);
            return "Success";
        }

        public async Task<string> EditTheaterAsync(Theater theater)
        {
            await _theaterRepository.UpdateAsync(theater);
            return "Success";
        }

        public async Task<Theater> GetTheaterByIdAsync(int id)
        {
            var theater = await _theaterRepository.GetByIdAsync(id);
            return theater;
        }

        public async Task<Theater> GetTheaterByIdWithIncludeAsync(int id)
        {
            var theater = await _theaterRepository.GetTableNoTracking().Include(x => x.Showtimes)
                                            .ThenInclude(x => x.Movie)
                                            .Where(x => x.Id == id)
                                            .FirstOrDefaultAsync();
            return theater;
        }
        public IQueryable<Theater> FilterTheaterPaginatedQuerable(TheaterOrderingEnum orderingEnum, string search)
        {
            var querable = _theaterRepository.GetTableNoTracking().AsQueryable();
            if (search != null)
                querable = querable.Where(x => x.Name.Contains(search));
            switch (orderingEnum)
            {
                case TheaterOrderingEnum.Id:
                    querable = querable.OrderBy(x => x.Id);
                    break;
                case TheaterOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.Name);
                    break;
                case TheaterOrderingEnum.totalSeats:
                    querable = querable.OrderBy(x => x.totalSeats);
                    break;
                default:
                    querable = querable.OrderBy(x => x.Id);
                    break;
            }
            return querable;
        }

        public async Task<bool> HasShowtimesAsync(int theaterId)
        {
            return await _showtimeRepository.GetTableNoTracking().AnyAsync(s => s.TheaterId == theaterId);
        }

        public async Task<string> DeleteTheaterAsync(Theater theater)
        {
            await _theaterRepository.DeleteAsync(theater);
            return "Success";
        }



        #endregion
    }
}
