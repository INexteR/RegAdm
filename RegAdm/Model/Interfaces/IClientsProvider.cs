using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IClientsProvider
    {
        ObservableCollection<ClientDTO> Clients { get; }
        void Add(ClientDTO client);
        void Remove(ClientDTO client);
        void Update(ClientDTO client);
    }
}
