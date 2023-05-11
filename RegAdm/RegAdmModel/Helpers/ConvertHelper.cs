using Model.DTOs;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegAdmModel.Helpers
{
    internal static class ConvertHelper
    {
        #region Методы ToDto
        public static RoomTypeDto ToDto(this RoomType roomType)
        {
            return new RoomTypeDto(roomType.Id, roomType.Name, roomType.Places, roomType.PricePerDay);
        }

        public static RoomDto ToDto(this Room room)
        {
            return new RoomDto(room.Id, room.Number, room.RoomTypeId);
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto(user.Id, user.FullName, user.BirthDate, user.Role, user.Login, user.Password);
        }

        public static ClientDto ToDto(this Client client)
        {
            return new ClientDto(client.Id, client.FullName, client.BirthDate, client.Seria, client.Number, client.Phone);
        }

        public static ReservationDto ToDto(this Reservation reservation)
        {
            return new ReservationDto(reservation.Id, reservation.BookingDate, reservation.RoomId, reservation.CheckInDate, reservation.EvictionDate, reservation.ActualEvictionDate, reservation.UserId);
        }
        #endregion

        #region Методы ToEntity
        public static RoomType ToEntity(this RoomTypeDto roomTypeDto)
        {
            return new RoomType(roomTypeDto.Id, roomTypeDto.Name, roomTypeDto.Places, roomTypeDto.PricePerDay);
        }

        public static Room ToEntity(this RoomDto roomDto)
        {
            return new Room(roomDto.Id, roomDto.Number, roomDto.RoomTypeId);
        }

        public static User ToEntity(this UserDto userDto)
        {
            return new User(userDto.Id, userDto.FullName, userDto.BirthDate, userDto.Role, userDto.Login, userDto.Password);
        }

        public static Client ToEntity(this ClientDto clientDto)
        {
            return new Client(clientDto.Id, clientDto.FullName, clientDto.BirthDate, clientDto.Seria, clientDto.Number, clientDto.Phone);
        }

        public static Reservation ToEntity(this ReservationDto reservationDto)
        {
            return new Reservation(reservationDto.Id, reservationDto.BookingDate, reservationDto.RoomId, reservationDto.CheckInDate, reservationDto.EvictionDate, reservationDto.ActualEvictionDate, reservationDto.UserId);
        }
        #endregion
    }
}
