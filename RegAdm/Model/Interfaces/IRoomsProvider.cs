using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRoomsProvider
    {
        IEnumerable<RoomTypeDTO> RoomTypes { get; }
        IEnumerable<RoomDTO> Rooms { get; }
    }
}
