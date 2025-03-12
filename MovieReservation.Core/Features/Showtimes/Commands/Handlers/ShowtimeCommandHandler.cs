using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Showtimes.Commands.Models;
using MovieReservation.Data.Entities;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Showtimes.Commands.Handlers
{
    public class ShowtimeCommandHandler : ResponseHandler,
                                                     IRequestHandler<AddShowtimeCommand, Response<string>>,
                                                     IRequestHandler<EditShowtimeCommand, Response<string>>,
                                                     IRequestHandler<DeleteShowtimeCommand, Response<string>>
    {

        #region Fields
        private readonly IShowtimeService _showtimeService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ShowtimeCommandHandler(IShowtimeService showtimeService, IMapper mapper)
        {
            _showtimeService = showtimeService;
            _mapper = mapper;
        }
        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddShowtimeCommand request, CancellationToken cancellationToken)
        {
            //mapping 
            var ShowtimeMapping = _mapper.Map<Showtime>(request);
            //Add
            var result = await _showtimeService.AddShowtimeAsync(ShowtimeMapping);
            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditShowtimeCommand request, CancellationToken cancellationToken)
        {
            //get old showtime
            var showtime = await _showtimeService.GetShowtimeByIdAsync(request.Id);
            //Return NotFound
            if (showtime == null) return NotFound<string>("Showtime NotFound");
            //Mapping
            var showtimeMapping = _mapper.Map<Showtime>(request);

            //Edit 
            var result = await _showtimeService.EditShowtimeAsync(showtimeMapping);

            //Return
            if (result == "Success") return Created($"Showtime Id = {showtimeMapping.Id}", "Edit Sussessfully");
            else if (result == "PastShowtime") return BadRequest<string>("Cant update a past showtime");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteShowtimeCommand request, CancellationToken cancellationToken)
        {
            //if Not Exist
            var showtime = await _showtimeService.GetShowtimeByIdAsync(request.Id);
            //Return NotFound
            if (showtime == null) return NotFound<string>("Showtime NotFound");

            //Delete 
            var result = await _showtimeService.DeleteShowtimeAsync(showtime);
            //Return
            if (result == "Success") return Deleted<string>();
            else if (result == "HasReservations") return BadRequest<string>("Cannot delete showtime because it has existing reservations.");
            else return BadRequest<string>("Failed to delete showtime due to an unexpected error.");
        }


        #endregion



    }
}
