using Microsoft.EntityFrameworkCore;
using Model.Interfaces;
using Model;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Mapping;
using static RegAdmModel.Helpers.Exceptions;

namespace RegAdmModel
{
    public partial class Registration
    {
        public event EntityChangeHandler<IReservation> ReservationChanged = delegate { };

        public void AddReservation(IReservation reservation)
        {
            ThrowIfIdNotZero(reservation);
            Reservation @new = reservation.Create<Reservation>();
            context.Reservations.Add(@new);
            context.SaveChanges();
            ReservationChanged(this, ActionChanges.Add, @new, @new);
        }

        public void RemoveReservation(IReservation reservation)
        {
            Reservation old = context.Reservations.Find(reservation.Id) ??
                throw new ArgumentException("Бронирования с таким Id нет.", nameof(reservation));
            if (old.Clients.Count != 0)
            {
                throw new InvalidOperationException("Бронирование нельзя удалить, так как на него есть ссылки в клиентах");
            }
            context.Reservations.Remove(old);
            context.SaveChanges();
            ReservationChanged(this, ActionChanges.Remove, old, old);
        }

        public void UpdateReservation(IReservation reservation)
        {
            Reservation old = context.Reservations.Find(reservation.Id) ??
                throw new ArgumentException("Бронирования с таким Id нет.", nameof(reservation));
            context.Entry(old).State = EntityState.Detached;
            Reservation @new = reservation.Create<Reservation>();
            context.Reservations.Update(@new);
            context.SaveChanges();
            ReservationChanged(this, ActionChanges.Update, old, @new);
        }
    }
}
