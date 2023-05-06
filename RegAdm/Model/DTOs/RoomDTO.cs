using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class RoomDTO
    {
        public int Id { get; }

        public short Number { get; }

        public int RoomTypeId { get; }

        public RoomDTO(int id, short number, int roomTypeId)
        {
            Id = id;
            Number = number;
            RoomTypeId = roomTypeId;
        }
    }
}
