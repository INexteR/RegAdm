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
        public event EntityChangeHandler<IClient> ClientChanged = delegate { };

        public void AddClient(IClient client)
        {
            ThrowIfIdNotZero(client);
            VerifyData(client);
            Client @new = client.Create<Client>();
            context.Clients.Add(@new);
            context.SaveChanges();
            ClientChanged(this, ActionChanges.Add, @new, @new);
        }

        public void RemoveClient(IClient client)
        {
            Client old = context.Clients.Find(client.Id) ??
                throw new ArgumentException("Клиента с таким Id нет.", nameof(client));
            if (old.Reservations.Count != 0)
            {
                throw new InvalidOperationException("Клиента нельзя удалить, так как на него есть ссылки в бронированиях");
            }
            context.Clients.Remove(old);
            context.SaveChanges();
            ClientChanged(this, ActionChanges.Remove, old, old);
        }

        public void UpdateClient(IClient client)
        {
            VerifyData(client);
            Client old = context.Clients.Find(client.Id) ??
                throw new ArgumentException("Клиента с таким Id нет.", nameof(client));
            context.Entry(old).State = EntityState.Detached;
            Client @new = client.Create<Client>();
            context.Clients.Update(@new);
            context.SaveChanges();
            ClientChanged(this, ActionChanges.Update, old, @new);
        }

        private void VerifyData(IClient client)
        {
            if (Clients.Any(c => c.Id != client.Id && c.Seria == client.Seria && c.Number == client.Number))
            {
                throw new InvalidOperationException("В базе данных уже есть клиент с предоставленными паспортными данными");
            }
            if (Clients.Any(c => c.Id != client.Id && c.Phone == client.Phone))
            {
                throw new InvalidOperationException("В базе данных уже есть клиент с данным телефоном");
            }
        }
    }
}
