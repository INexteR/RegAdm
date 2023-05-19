using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("roomtypes")]
    internal partial class RoomType : IRoomType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public sbyte Places { get; set; }

        public int PricePerDay { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        IEnumerable<IRoom> IRoomType.Rooms => Rooms;

        public RoomType() { }
        public RoomType(int id, string name, sbyte places, int pricePerDay)
        {
            Id = id;
            Name = name;
            Places = places;
            PricePerDay = pricePerDay;
        }
    }
}


