using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;
using static RegAdmModel.RegistrationSettings;
using Microsoft.EntityFrameworkCore;
using RegAdmModel.Entities;
using System.Reflection.Metadata;

namespace RegAdmModel
{
    public partial class Registration : IRegistration, IAuthorization, ILoadSources
    {
        private readonly RegAdmContext context;

        public Registration(bool recreate = false)
        {
            if (recreate)
            {
                if (File.Exists(CONNECTION))
                    File.Delete(CONNECTION);
            }
            context = new RegAdmContext(CONNECTION);
            context.Database.EnsureCreated();
         
            roomTypes = context.RoomTypes.Local.ToObservableCollection();
            rooms = context.Rooms.Local.ToObservableCollection();
            users = context.Users.Local.ToObservableCollection();
            clients = context.Clients.Local.ToObservableCollection();
            reservations = context.Reservations.Local.ToObservableCollection();
        }
        public Task LoadAsync() => Task.Run(() =>
        {
            context.RoomTypes.Load();
            context.Rooms.Load();
            context.Users.Load();
            context.Clients.Load();
            context.Reservations.Load();

            SourcesLoaded(this, EventArgs.Empty);
        });

        public event EventHandler SourcesLoaded = delegate { };

        private readonly ObservableCollection<RoomType> roomTypes;
        private readonly ObservableCollection<Room> rooms;
        private readonly ObservableCollection<User> users;
        private readonly ObservableCollection<Client> clients;
        private readonly ObservableCollection<Reservation> reservations;

        public IEnumerable<IRoomType> RoomTypes => roomTypes;
        public IEnumerable<IRoom> Rooms => rooms;
        public IEnumerable<IUser> Users => users;
        public IEnumerable<IClient> Clients => clients;
        public IEnumerable<IReservation> Reservations => reservations;
    }

    public static class RegistrationSettings
    {
        public const string CONNECTION = "RegAdmSQLite.db";
        public const string ADMINISTRATOR = "Администратор";
        public const string SENIOR_ADMINISTRATOR = $"Старший администратор";
    }
}
