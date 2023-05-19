using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRegistration : IAuthorization, ILoadSources
    {
        IEnumerable<IRoomType> RoomTypes { get; }
        IEnumerable<IRoom> Rooms { get; }
        IEnumerable<IUser> Users { get; }
        IEnumerable<IClient> Clients { get; }
        IEnumerable<IReservation> Reservations { get;  }

        event EntityChangeHandler<IUser> UserChanged;
        event EntityChangeHandler<IClient> ClientChanged;
        event EntityChangeHandler<IReservation> ReservationChanged;

        void AddUser(IUser user);
        void RemoveUser(IUser user);
        void UpdateUser(IUser user);

        void AddClient(IClient client);
        void RemoveClient(IClient client);
        void UpdateClient(IClient client);

        void AddReservation(IReservation reservation);
        //void RemoveReservaton(IReservation reservation);
        void UpdateReservation(IReservation reservation);
    }
}
