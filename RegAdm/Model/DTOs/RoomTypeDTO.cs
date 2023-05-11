using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class RoomTypeDto : IdDto
    {
        public string Name { get; set; }

        public sbyte Places { get; set; }

        public int PricePerDay { get; set; }

        public RoomTypeDto(int id, string name, sbyte places, int pricePerDay) : base(id)
        {
            Name = name;
            Places = places;
            PricePerDay = pricePerDay;
        }      
    }
}
