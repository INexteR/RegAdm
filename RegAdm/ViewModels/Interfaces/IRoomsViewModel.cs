using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Proxies;

namespace ViewModels.Interfaces
{
    public interface IRoomsViewModel
    {
        IEnumerable<RoomTypeProxy> RoomTypes { get; }
        IEnumerable<RoomProxy> Rooms { get; }
    }
}
