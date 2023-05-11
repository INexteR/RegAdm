using Model.DTOs;
using Model.Interfaces;
using RegAdmModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RegAdmModel.RegistrationSettings;
using static RegAdmModel.Helpers.Exceptions;
using RegAdmModel.Helpers;

namespace RegAdmModel.Repositories
{
    internal class ClientsRepository : IClientsRepository
    {
        public event EntityChangeHandler<ClientDto> EntityChanged = delegate { };

        public ClientDto? Get(int id)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Clients.Find(id)?.ToDto();
        }

        public IEnumerable<ClientDto> GetAll()
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Clients.ToList().Select(ConvertHelper.ToDto);
        }

        public IEnumerable<ClientDto> GetClientsForReservation(int reservationId)
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.Reservations.Find(reservationId)?.Clients
                .ToList().Select(ConvertHelper.ToDto) ?? Enumerable.Empty<ClientDto>();
        }

        public bool Add(ClientDto clientDto)
        {
            ThrowIfIdNotZero(clientDto);
            bool result;
            var client = clientDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                context.Clients.Add(client);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = client.ToDto();
                EntityChanged(this, ActionChanges.Add, clientDto, newDto);
            }
            return result;
        }

        public bool Remove(ClientDto clientDto)
        {
            bool result;
            var client = clientDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                var query = context.Clients.Attach(client).Collection(с => с.Reservations).Query();
                if (query.FirstOrDefault() != null)
                {
                    throw new InvalidOperationException("Клиента нельзя удалить, так как на него есть ссылки в бронированиях");
                }
                context.Clients.Remove(client);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = client.ToDto();
                EntityChanged(this, ActionChanges.Remove, clientDto, newDto);
            }
            return result;
        }

        public bool Update(ClientDto clientDto)
        {
            bool result;
            var client = clientDto.ToEntity();
            using (var context = new RegAdmContext(CONNECTION))
            {
                context.Clients.Update(client);
                result = context.SaveChanges() > 0;
            }
            if (result)
            {
                var newDto = client.ToDto();
                EntityChanged(this, ActionChanges.Update, clientDto, newDto);
            }
            return result;
        }
    }
}
