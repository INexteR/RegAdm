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
        private readonly RoomTypeDTO _roomType;

        public string Name => _roomType.Name;

        public sbyte Places => _roomType.Places;

        public int PricePerDay => _roomType.PricePerDay;
        
        public RoomTypeProxy(RoomTypeDTO roomType)
        {
            _roomType = roomType;
        }
    }
}
