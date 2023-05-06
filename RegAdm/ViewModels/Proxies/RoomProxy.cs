using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ViewModels.Proxies
{
    public class RoomProxy
    {
        private readonly RoomDTO _room;

        public short Number => _room.Number;

        public RoomTypeProxy RoomType => _roomTypes[_room.RoomTypeId];

        private readonly IDictionary<int, RoomTypeProxy> _roomTypes;

        public RoomProxy(RoomDTO room, IDictionary<int, RoomTypeProxy> roomTypes)
        {
            _room = room;
            _roomTypes = roomTypes;
        }
    }
}
