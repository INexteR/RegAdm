using Model.DTOs;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Proxies
{
    public class ReservationProxy : IdProxy<ReservationDto>
    {
        public DateOnly BookingDate => Data.BookingDate;

        public int Days => EvictionDate.ToDateTime(default).Subtract(CheckInDate.ToDateTime(default)).Days;

        public DateOnly CheckInDate => Data.CheckInDate;

        public DateOnly EvictionDate => Data.EvictionDate;

        public bool IsActual => CheckInDate != EvictionDate && CheckInDate != ActualEvictionDate;

        public DateOnly ActualEvictionDate => Data.ActualEvictionDate;

        public RoomProxy? Room => _rooms?[Data.RoomId];

        public UserProxy? User => _users?[Data.UserId];

        private readonly IDictionary<int, RoomProxy>? _rooms;
        private readonly IDictionary<int, UserProxy>? _users;

        public ReservationProxy(ReservationDto reservation, IDictionary<int, RoomProxy>? rooms = null, IDictionary<int, UserProxy>? users = null) 
            : base (reservation.Id, reservation)
        {
            _rooms = rooms;
            _users = users;
        }
    }
}
