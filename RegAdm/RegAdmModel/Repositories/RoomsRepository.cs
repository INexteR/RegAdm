using Model.DTOs;
using Model.Interfaces;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RegAdmModel.RegistrationSettings;
using RegAdmModel.Helpers;

namespace RegAdmModel.Repositories
{
    internal class RoomsRepository : IRoomsRepository
    {
        public event EntityChangeHandler<RoomDto> EntityChanged = delegate { };

        public RoomDto? Get(int id)
        {
            using var context = new RegAdmContext(CONNECTION);
            var room = context.Rooms.Find(id);
            return room?.ToDto();
        }

        public RoomDto? GetRoomForReservation(int reservationId)
        {
            using var context = new RegAdmContext(CONNECTION);
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                context.Reservations.Entry(reservation).Reference(r => r.Room).Load();
                return reservation.Room.ToDto();
            }
            return null;
        }

        public IEnumerable<RoomDto> GetAll()
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Rooms.ToList().Select(ConvertHelper.ToDto);
        }

        public IEnumerable<RoomDto> GetRoomsForType(int roomTypeId)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Rooms.Where(r => r.RoomTypeId == roomTypeId)
                .ToList().Select(ConvertHelper.ToDto);
        }

        public bool Add(RoomDto _) => throw Exceptions.NotImplemented;
        public bool Remove(RoomDto _) => Add(_);
        public bool Update(RoomDto _) => Add(_);
    }
}
