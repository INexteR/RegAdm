using Model.Interfaces;
using RegAdmModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;
using Model.Collection;
using Model;

namespace RegAdmViewModels
{
    public class ClientsViewModel : ViewModelBase, IClientsViewModel
    {
        private readonly IRegistration _registration;
        private readonly ObservableCollection<IClient> clients;

        public IEnumerable<IClient> Clients => clients;

        public ClientsViewModel(IRegistration registration)
        {
            _registration = registration;
            clients = new(_registration.Clients);
            _registration.SourcesLoaded += OnSourcesLoaded;
            _registration.ClientChanged += OnEntityChanged;
        }

        private void OnSourcesLoaded(object? sender, EventArgs e)
        {
            clients.Reset(_registration.Clients);
        }

        private void OnEntityChanged(IRegistration source, ActionChanges action, IClient old, IClient @new)
        {
            switch (action)
            {
                case ActionChanges.Remove:
                    clients.FirstRemove(u => u.Id == old.Id);
                    break;
                default:
                    clients.ReplaceOrAdd(@new, (c1, c2) => c1.Id == c2.Id);
                    break;
            }
        }

        public ClientsViewModel() : this(new Registration()) { }

        public RelayCommand<IClient> AddClient => GetCommand((ExecuteHandler<IClient>)_registration.AddClient);

        public RelayCommand<IClient> UpdateClient => GetCommand((ExecuteHandler<IClient>)_registration.UpdateClient);

        public RelayCommand<IClient> RemoveClient => GetCommand((ExecuteHandler<IClient>)_registration.RemoveClient);

        public override string ToString()
        {
            return "Клиенты";
        }
    }
}
