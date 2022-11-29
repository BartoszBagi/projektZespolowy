﻿using Gadajec.Application.Common.Interfaces;
using Gadajec.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadajec.Application.Commands.RoomCommands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IGadajecDBContext _gadajecDBContext;
        private readonly IDateTime _dateTime;
        public CreateRoomCommandHandler(IGadajecDBContext gadajecDBContext, IDateTime dateTime)
        {
            _gadajecDBContext = gadajecDBContext;
            _dateTime = dateTime;
        }

        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            if (_gadajecDBContext.Rooms.Any(r => r.Name == request.Name))
            {
                return false;
            }

            else
            {
                Room room = new Room()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    CreatedBy = request.CreatedBy,
                    CreatedAt = _dateTime.Now
                };


                _gadajecDBContext.Rooms.Add(room);
                await _gadajecDBContext.SaveChangesAsync(true);

                return true;
            }
        }

    }
}
