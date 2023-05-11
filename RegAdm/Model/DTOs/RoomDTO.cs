using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class RoomDto : IdDto
    {
        public short Number { get; set; }

        public int RoomTypeId { get; set; }

        public RoomDto(int id, short number, int roomTypeId) : base(id)
        {
            Number = number;
            RoomTypeId = roomTypeId;
        }
    }
}
