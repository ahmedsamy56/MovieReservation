using AutoMapper;
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Theaters.Commands.Models;
using MovieReservation.Data.Entities;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Theaters.Commands.Handlers
{
    public class TheaterCommandHandler : ResponseHandler,
                                                        IRequestHandler<AddTheaterCommand, Response<string>>,
                                                        IRequestHandler<EditTheaterCommand, Response<string>>,
                                                        IRequestHandler<DeleteTheaterCommand, Response<string>>
    {

        #region Fields
        private readonly ITheaterService _TheaterService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public TheaterCommandHandler(ITheaterService TheaterService, IMapper mapper)
        {
            _TheaterService = TheaterService;
            _mapper = mapper;
        }
        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddTheaterCommand request, CancellationToken cancellationToken)
        {
            //mapping
            var TheaterMapping = _mapper.Map<Theater>(request);

            //Add
            var result = await _TheaterService.AddTheaterAsync(TheaterMapping);

            //return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditTheaterCommand request, CancellationToken cancellationToken)
        {
            //get old Theater 
            var theater = await _TheaterService.GetTheaterByIdAsync(request.Id);

            //Return NotFound
            if (theater == null) return NotFound<string>("Theater NotFound");

            //mapping
            var theaterMapping = _mapper.Map<Theater>(request);

            //Edit 
            var result = await _TheaterService.EditTheaterAsync(theaterMapping);

            if (result == "Success") return Created($"Theater Id = {theaterMapping.Id}", "Edit Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteTheaterCommand request, CancellationToken cancellationToken)
        {
            //if Not Exist
            var theater = await _TheaterService.GetTheaterByIdAsync(request.Id);

            //Return NotFound
            if (theater == null) return NotFound<string>("Theater NotFound");

            //Check for deletion
            bool hasShowtimes = await _TheaterService.HasShowtimesAsync(request.Id);
            if (hasShowtimes)
                return BadRequest<string>("Theater cannot be deleted because it has showtimes");
            //Delete 
            var result = await _TheaterService.DeleteTheaterAsync(theater);
            //Return
            if (result == "Success") return Deleted<string>();
            else return BadRequest<string>();
        }


        #endregion

    }
}
