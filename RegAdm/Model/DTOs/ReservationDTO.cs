using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ReservationDto : IdDto
    {
        public DateOnly BookingDate { get; set; }

        public int RoomId { get; set; }

        public DateOnly CheckInDate { get; set; }

        public DateOnly EvictionDate { get; set; }

        public DateOnly ActualEvictionDate { get; set; }

        public int UserId { get; set; }

        public ReservationDto(int id, DateOnly bookingDate, int roomId, DateOnly checkInDate, DateOnly evictionDate, DateOnly actualEvictionDate, int userId)
            : base(id)
        {
            BookingDate = bookingDate;
            RoomId = roomId;
            CheckInDate = checkInDate;
            EvictionDate = evictionDate;
            ActualEvictionDate = actualEvictionDate;
            UserId = userId;
        }
    }
}
