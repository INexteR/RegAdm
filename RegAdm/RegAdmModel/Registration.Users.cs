using Model;
using Model.Interfaces;
using Model.Mapping;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static RegAdmModel.Helpers.Exceptions;

namespace RegAdmModel
{
    public partial class Registration
    {
        public event EntityChangeHandler<IUser> UserChanged = delegate { };

        public void AddUser(IUser user)
        {
            ThrowIfIdNotZero(user);
            User @new = user.Create<User>();
            context.Users.Add(@new);
            context.SaveChanges();
            UserChanged(this, ActionChanges.Add, @new, @new);
        }

        public void RemoveUser(IUser user)
        {
            User old = context.Users.Find(user.Id) ??
                throw new ArgumentException("Пользователя с таким Id нет.", nameof(user));
            if (old.Reservations.Count != 0)
            {
                throw new InvalidOperationException("Сотрудника нельзя удалить, так как на него есть ссылки в бронированиях");
            }
            context.Users.Remove(old);
            context.SaveChanges();
            UserChanged(this, ActionChanges.Remove, old, old);
        }

        public void UpdateUser(IUser user)
        {
            User old = context.Users.Find(user.Id) ??
                throw new ArgumentException("Пользователя с таким Id нет.", nameof(user));
            context.Entry(old).State = EntityState.Detached;
            User @new = user.Create<User>();
            context.Users.Update(@new);
            context.SaveChanges();
            UserChanged(this, ActionChanges.Update, old, @new);
        }
    }
}
