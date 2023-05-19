using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IReservation : IIdEntity
    {
        DateOnly BookingDate { get; }

        int RoomId { get; }

        bool IsActual { get; }

        int TotalDays { get; }

        DateOnly CheckInDate { get; }

        DateOnly EvictionDate { get; }

        DateOnly ActualEvictionDate { get; }

        int UserId { get; }

        IRoom Room { get; }
        
        IUser User { get; }
        
        IEnumerable<IClient> Clients { get; }
    }
}
