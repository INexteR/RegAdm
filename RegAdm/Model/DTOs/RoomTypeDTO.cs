using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class RoomTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public sbyte Places { get; set; }

        public int PricePerDay { get; set; }

        public RoomTypeDTO(int id, string name, sbyte places, int pricePerDay)
        {
            Id = id;
            Name = name;
            Places = places;
            PricePerDay = pricePerDay;
        }      
    }
}
