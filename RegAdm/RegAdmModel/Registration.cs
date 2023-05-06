using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Interfaces;
using RegAdmModel.Entities;
using Model.DTOs;
using System.Collections.ObjectModel;

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

            Users = new(Select(context.Users, UserToUserDTO));
            Clients = new(Select(context.Clients, ClientToClientDTO));
            RoomTypes = Select(context.RoomTypes, RoomTypeToRoomTypeDTO);
            Rooms = Select(context.Rooms, RoomToRoomDTO);
            Reservations = new(Select(context.Reservations, ReservationToReservationDTO));
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

        public ObservableCollection<UserDTO> Users { get; }
        public ObservableCollection<ClientDTO> Clients { get; }
        public IEnumerable<RoomTypeDTO> RoomTypes { get; }
        public IEnumerable<RoomDTO> Rooms { get; }
        public ObservableCollection<ReservationDTO> Reservations { get; }

        #region Функции-преобразователи
        private static IEnumerable<TResult> Select<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector);
        }

        private static UserDTO UserToUserDTO(User user)
        {
            return new(user.Id, user.FullName, user.BirthDate, user.Role, user.Login, user.Password);
        }
        private static ClientDTO ClientToClientDTO(Client client)
        {
            return new(client.Id, client.FullName, client.BirthDate, client.Seria, client.Number, client.Phone);
        }
        private static RoomTypeDTO RoomTypeToRoomTypeDTO(RoomType roomType)
        {
            return new(roomType.Id, roomType.Name, roomType.Places, roomType.PricePerDay);
        }
        private static RoomDTO RoomToRoomDTO(Room room)
        {
            return new(room.Id, room.Number, room.RoomTypeId);
        }
        private static ReservationDTO ReservationToReservationDTO(Reservation reservation)
        {
            return new(reservation.Id, reservation.BookingDate, reservation.RoomId, reservation.CheckInDate,
                reservation.EvictionDate, reservation.ActualEvictionDate, reservation.UserId);
        }
        #endregion

        void IClientsProvider.Add(ClientDTO client)
        {
            
        }

        void IClientsProvider.Remove(ClientDTO client)
        {
            
        }

        void IClientsProvider.Update(ClientDTO client)
        {
            
        }
    }
}
