using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Interfaces;
using RegAdmModel.Entities;

namespace RegAdmModel
{
    public partial class Registration : IRegistration, ILoadSources, IAuthorization
    {
        const string CONNECTION = "RegAdmSQLite.db";

        private readonly RegAdmContext context;

        public Registration(bool recreate = false)
        {
            if (recreate)
            {
                if (File.Exists(CONNECTION))
                    File.Delete(CONNECTION);
            }
            context = new(CONNECTION);
            context.Database.EnsureCreated();

            Users = context.Users.Local.ToObservableCollection();
            Clients = context.Clients.Local.ToObservableCollection();
            RoomTypes = context.RoomTypes.Local.ToObservableCollection();
            Rooms = context.Rooms.Local.ToObservableCollection();
            Reservations = context.Reservations.Local.ToObservableCollection();
        }
        public event EventHandler SourcesLoaded = delegate { };

        public Task LoadDataAsync() => Task.Run(() =>
        {
            context.Users.Load();
            context.Clients.Load();
            context.RoomTypes.Load();
            context.Rooms.Load();
            context.Reservations.Load();

            SourcesLoaded(this, EventArgs.Empty);
        });

        public IEnumerable<User> Users { get; }
        public IEnumerable<RoomType> RoomTypes { get; }
        public IEnumerable<Room> Rooms { get; }
        public IEnumerable<Client> Clients { get; }
        public IEnumerable<Reservation> Reservations { get; }

        IEnumerable<dynamic> IRoomsProvider.RoomTypes => RoomTypes;
        IEnumerable<dynamic> IRoomsProvider.Rooms => Rooms;
    }
}
