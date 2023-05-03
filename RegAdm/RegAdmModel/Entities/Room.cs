using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("rooms")]
    [Index(nameof(RoomTypeId), Name = "roomtype_idx")]
    [Index(nameof(Number), IsUnique = true)]
    public partial class Room
    {
        [Key]
        public int Id { get; set; }
        
        public short Number { get; set; }

        public int RoomTypeId { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public virtual RoomType RoomType { get; set; } = null!;
    }
}


