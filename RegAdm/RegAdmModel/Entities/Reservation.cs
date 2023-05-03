using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("reservations")]
    [Index(nameof(RoomId), Name = "room_idx")]
    [Index(nameof(UserId), Name = "user_idx")]
    public partial class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateOnly BookingDate { get; set; }

        public int RoomId { get; set; }

        [NotMapped]
        public int Days => EvictionDate.ToDateTime(default).Subtract(CheckInDate.ToDateTime(default)).Days;

        public DateOnly CheckInDate { get; set; }

        public DateOnly EvictionDate { get; set; }

        [NotMapped]
        public bool IsActual => CheckInDate != EvictionDate && CheckInDate != ActualEvictionDate;

        public DateOnly ActualEvictionDate { get; set; }

        public int UserId { get; set; }

        public virtual Room Room { get; set; } = null!;

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}


