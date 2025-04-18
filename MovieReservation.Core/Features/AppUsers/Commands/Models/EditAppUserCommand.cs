﻿using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.AppUsers.Commands.Models
{
    public class EditAppUserCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
