using Microsoft.EntityFrameworkCore;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("reservations")]
    [Index(nameof(RoomId), Name = "room_idx")]
    [Index(nameof(UserId), Name = "user_idx")]
    internal partial class Reservation : IReservation
    {
        [Key]
        public int Id { get; set; }

        public DateOnly BookingDate { get; set; }

        public int RoomId { get; set; }

        public bool IsActual => CheckInDate < ActualEvictionDate && CheckInDate < EvictionDate;

        public int TotalDays => ActualEvictionDate.ToDateTime(default).Subtract(CheckInDate.ToDateTime(default)).Days;

        public DateOnly CheckInDate { get; set; }

        public DateOnly EvictionDate { get; set; }

        public DateOnly ActualEvictionDate { get; set; }

        public int UserId { get; set; }

        public virtual Room Room { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        IRoom IReservation.Room => Room;

        IUser IReservation.User => User;

        IEnumerable<IClient> IReservation.Clients => Clients;

        public Reservation() { }
        public Reservation(int id, DateOnly bookingDate, int roomId, DateOnly checkInDate, DateOnly evictionDate, DateOnly actualEvictionDate, int userId)
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


