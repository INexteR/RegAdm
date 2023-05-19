using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRoom : IIdEntity
    {
        short Number { get; }

        int RoomTypeId { get; }

        IEnumerable<IReservation> Reservations { get; }

        IRoomType RoomType { get; }
    }
}
