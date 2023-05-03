using Model.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegAdmModel.Entities;

namespace RegAdmModel
{
    public partial class Registration : IAuthorization
    {
        public AuthorizationStatus Status { get; private set; }
        public IUser? CurrentUser { get; private set; }

        private void OnAuthorizationChanged()
        {
            AuthorizationChanged(this, new AuthorizationChangedArgs(Status, CurrentUser));
        }

        public event EventHandler<AuthorizationChangedArgs> AuthorizationChanged = delegate { };

        public void Exit()
        {
            if (Status != AuthorizationStatus.Authorized)
                throw new Exception($"Выход возможен только из состояния {AuthorizationStatus.Authorized}.");

            lock (this)
            {
                Status = AuthorizationStatus.None;
                CurrentUser = null;
                OnAuthorizationChanged();
            }
        }

        public void Authorize(string login, string password)
        {
            (login, password) = (login.Trim(), password.Trim());
            lock (this)
            {
                if (Status is AuthorizationStatus.InProcessing or AuthorizationStatus.Authorized)
                    throw new Exception($"Запрос новой авторизации возможен в состояниях {AuthorizationStatus.None} и {AuthorizationStatus.Fail}.");
                Status = AuthorizationStatus.InProcessing;
                OnAuthorizationChanged();
            }

            Thread.Sleep(new Random().Next(500, 2000));

            User? user = context.Users.FirstOrDefault(user => user.Login == login && user.Password == password);

            if (user != null)
            {
                lock (this)
                {
                    Status = AuthorizationStatus.Authorized;
                    CurrentUser = user;
                }
            }
            else
            {
                lock (this)
                {
                    Status = AuthorizationStatus.Fail;
                }
            }
            OnAuthorizationChanged();
        }

        public Task AuthorizeAsync(string login, string password)
            => Task.Run(() => Authorize(login, password));

    }
}
