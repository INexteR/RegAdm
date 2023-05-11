using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ViewModels.Proxies
{
    public class RoomTypeProxy
    {
        private readonly RoomTypeDto _roomType;

        public int Id => _roomType.Id;

        public string Name => _roomType.Name;

        public sbyte Places => _roomType.Places;

        public int PricePerDay => _roomType.PricePerDay;
        
        public RoomTypeProxy(RoomTypeDto roomType)
        {
            _roomType = roomType;
        }
    }
}
