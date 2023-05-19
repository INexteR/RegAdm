using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IRoomsViewModel
    {
        IEnumerable<IRoomType> RoomTypes { get; } 
        IEnumerable<IRoom> Rooms { get; }
    }
}
