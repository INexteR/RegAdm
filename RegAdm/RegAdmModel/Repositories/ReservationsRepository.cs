using Model.DTOs;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegAdmModel.Helpers;
using static RegAdmModel.RegistrationSettings;
using static RegAdmModel.Helpers.Exceptions;
using RegAdmModel.Entities;

namespace RegAdmModel.Repositories
{
    internal class ReservationsRepository : IReservationsRepository
    {
        public event EntityChangeHandler<ReservationDto> EntityChanged = delegate { };

        public ReservationDto? Get(int id)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Reservations.Find(id)?.ToDto();
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Reservations.ToList().Select(ConvertHelper.ToDto);
        }

        public IEnumerable<ReservationDto> GetReservationsForClient(int clientId)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Clients.Find(clientId)?.Reservations.ToList()
                .Select(ConvertHelper.ToDto) ?? Enumerable.Empty<ReservationDto>();
        }

        public IEnumerable<ReservationDto> GetReservationsForRoom(int roomId)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Rooms.Find(roomId)?.Reservations.ToList()
                .Select(ConvertHelper.ToDto) ?? Enumerable.Empty<ReservationDto>();
        }

        public IEnumerable<ReservationDto> GetReservationsForUser(int userId)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Users.Find(userId)?.Reservations.ToList()
                .Select(ConvertHelper.ToDto) ?? Enumerable.Empty<ReservationDto>();
        }

        public bool Add(ReservationDto reservationDto)
        {
            ThrowIfIdNotZero(reservationDto);
            bool result;
            var reservation = reservationDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                context.Reservations.Add(reservation);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = reservation.ToDto();
                EntityChanged(this, ActionChanges.Add, reservationDto, newDto);
            }
            return result;
        }

        public bool Remove(ReservationDto reservationDto)
        {
            bool result;
            var reservation = reservationDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                var query = context.Reservations.Attach(reservation).Collection(r => r.Clients).Query();
                if (query.FirstOrDefault() != null)
                {
                    throw new InvalidOperationException("Бронирование нельзя удалить, так как на него есть ссылки в клиентах");
                }
                context.Reservations.Remove(reservation);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = reservation.ToDto();
                EntityChanged(this, ActionChanges.Remove, reservationDto, newDto);
            }
            return result;
        }

        public bool Update(ReservationDto reservationDto)
        {
            ThrowIfIdNotZero(reservationDto);
            bool result;
            var reservation = reservationDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                context.Reservations.Update(reservation);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = reservation.ToDto();
                EntityChanged(this, ActionChanges.Update, reservationDto, newDto);
            }
            return result;
        }
    }
}
