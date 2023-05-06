using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public DateOnly BookingDate { get; set; }

        public int RoomId { get; set; }

        public int Days => EvictionDate.ToDateTime(default).Subtract(CheckInDate.ToDateTime(default)).Days;

        public DateOnly CheckInDate { get; set; }

        public DateOnly EvictionDate { get; set; }

        public bool IsActual => CheckInDate != EvictionDate && CheckInDate != ActualEvictionDate;

        public DateOnly ActualEvictionDate { get; set; }

        public int UserId { get; set; }

        public ReservationDTO(int id, DateOnly bookingDate, int roomId, DateOnly checkInDate, DateOnly evictionDate, DateOnly actualEvictionDate, int userId)
        {
            Id = id;
            BookingDate = bookingDate;
            RoomId = roomId;
            CheckInDate = checkInDate;
            EvictionDate = evictionDate;
            ActualEvictionDate = actualEvictionDate;
            UserId = userId;
        }
    }
}
