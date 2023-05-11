using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRegistration : IAuthorization
    {
        IClientsRepository ClientsRepository { get; }
        IUsersRepository UsersRepository { get; }
        IRoomsRepository RoomsRepository { get; }
        IRoomTypesRepository RoomTypesRepository { get; }
        IReservationsRepository ReservationsRepository { get; }
    }
}
