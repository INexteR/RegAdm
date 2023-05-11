using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using static RegAdmModel.RegistrationSettings;
using RegAdmModel.Repositories;

namespace RegAdmModel
{
    public partial class Registration : IRegistration, IAuthorization
    {
        public Registration()
        {
            RoomTypesRepository = new RoomTypesRepository();
            RoomsRepository = new RoomsRepository();
            UsersRepository = new UsersRepository();
            ClientsRepository = new ClientsRepository();
            ReservationsRepository = new ReservationsRepository();
            Init();
        }

        public IRoomTypesRepository RoomTypesRepository { get; }
        public IRoomsRepository RoomsRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public IClientsRepository ClientsRepository { get; }
        public IReservationsRepository ReservationsRepository { get; }

        private static void Init()
        {
            using var context = new RegAdmContext(CONNECTION);
            context.Database.EnsureCreated();
        }
    }

    internal static class RegistrationSettings
    {
        public const string CONNECTION = "RegAdmSQLite.db";
    }
}
