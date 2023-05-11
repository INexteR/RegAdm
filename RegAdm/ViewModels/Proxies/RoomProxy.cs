using Model.DTOs;
using Model.Interfaces;
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
        private readonly RoomDto _room;

        public int Id => _room.Id;

        public short Number => _room.Number;

        public RoomTypeProxy RoomType { get; }

        public int Places { get; }

        public RoomProxy(RoomDto room, RoomTypeProxy roomType, int places)
        {
            _room = room;
            RoomType = roomType;
            Places = places;
        }
    }
}
