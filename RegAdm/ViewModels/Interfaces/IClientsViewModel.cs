using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IClientsViewModel
    {
        IEnumerable<IClient> Clients { get; }

        RelayCommand<IClient> AddClient { get; }

        RelayCommand<IClient> UpdateClient { get; }

        RelayCommand<IClient> RemoveClient { get; }
    }
}
