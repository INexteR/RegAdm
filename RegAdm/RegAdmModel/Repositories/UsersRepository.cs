using Model.DTOs;
using Model.Interfaces;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegAdmModel.Helpers;
using static RegAdmModel.Helpers.Exceptions;
using static RegAdmModel.RegistrationSettings;

namespace RegAdmModel.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        public event EntityChangeHandler<UserDto> EntityChanged = delegate { };

        public UserDto? Get(int id)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Users.Find(id)?.ToDto();
        }

        public UserDto? GetUserForReservation(int reservationId)
        {
            using var context = new RegAdmContext(CONNECTION);
            var reservation = context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                context.Reservations.Entry(reservation).Reference(r => r.User).Load();
                return reservation.User.ToDto();
            }
            return null;
        }

        public IEnumerable<UserDto> GetAll()
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Users.ToList().Select(ConvertHelper.ToDto);
        }

        public bool Add(UserDto userDto)
        {
            ThrowIfIdNotZero(userDto);
            bool result;
            var user = userDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                context.Users.Add(user);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = user.ToDto();
                EntityChanged(this, ActionChanges.Add, userDto, newDto);
            }
            return result;
        }

        public bool Remove(UserDto userDto)
        {
            bool result;
            var user = userDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                var query = context.Users.Attach(user).Collection(u => u.Reservations).Query();
                if (query.FirstOrDefault() != null)
                {
                    throw new InvalidOperationException("Сотрудника нельзя удалить, так как на него есть ссылки в бронированиях");
                }
                context.Users.Remove(user);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = user.ToDto();
                EntityChanged(this, ActionChanges.Remove, userDto, newDto);
            }
            return result;
        }

        public bool Update(UserDto userDto)
        {
            bool result;
            var user = userDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {               
                context.Users.Update(user);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = user.ToDto();
                EntityChanged(this, ActionChanges.Update, userDto, newDto);
            }
            return result;
        }
    }
}
