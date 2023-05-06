using Model.DTOs;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Proxies
{
    public class ReservationProxy : IdProxy<ReservationDTO>
    {
        public DateOnly BookingDate => Data.BookingDate;

        public DateOnly CheckInDate => Data.CheckInDate;

        public DateOnly EvictionDate => Data.EvictionDate;

        public DateOnly ActualEvictionDate => Data.ActualEvictionDate;

        public RoomProxy Room => _rooms[Data.RoomId];

        public UserProxy User => _users[Data.UserId];

        private readonly IDictionary<int, RoomProxy> _rooms;
        private readonly IDictionary<int, UserProxy> _users; 

        public ReservationProxy(ReservationDTO reservation, IDictionary<int, RoomProxy> rooms, IDictionary<int, UserProxy> users) : base (reservation.Id, reservation)
        {
            _rooms = rooms;
            _users = users;
        }
    }
}
