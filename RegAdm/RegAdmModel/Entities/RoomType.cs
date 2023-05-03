﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("roomtypes")]
    public partial class RoomType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public sbyte Places { get; set; }

        public int PricePerDay { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}

