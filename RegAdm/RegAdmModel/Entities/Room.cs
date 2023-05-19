using Microsoft.EntityFrameworkCore;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("rooms")]
    [Index(nameof(RoomTypeId), Name = "roomtype_idx")]
    [Index(nameof(Number), IsUnique = true)]
    internal partial class Room : IRoom
    {
        [Key]
        public int Id { get; set; }
        
        public short Number { get; set; }

        public int RoomTypeId { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public virtual RoomType RoomType { get; set; } = null!;

        IEnumerable<IReservation> IRoom.Reservations => Reservations;

        IRoomType IRoom.RoomType => RoomType;

        public Room() { }
        public Room(int id, short number, int roomTypeId)
        {
            Id = id;
            Number = number;
            RoomTypeId = roomTypeId;
        }
    }
}


