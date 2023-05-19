using Model.Collection;
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
using Model;

namespace RegAdmViewModels
{
    public class UsersViewModel : ViewModelBase, IUsersViewModel
    {
        private readonly IRegistration _registration; 
        private readonly ObservableCollection<IUser> users;

        public IEnumerable<IUser> Users => users;

        public UsersViewModel(IRegistration registration)
        {
            _registration = registration;
            users = new(_registration.Users);
            _registration.SourcesLoaded += OnSourcesLoaded;
            _registration.UserChanged += OnEntityChanged;
        }

        private void OnSourcesLoaded(object? sender, EventArgs e)
        {
            users.Reset(_registration.Users);
        }

        private void OnEntityChanged(IRegistration source, ActionChanges action, IUser old, IUser @new)
        {
            switch (action)
            {
                case ActionChanges.Remove:
                    users.FirstRemove(u => u.Id == old.Id);
                    break;
                default:
                    users.ReplaceOrAdd(@new, (u1, u2) => u1.Id == u2.Id);
                    break;
            }
        }

        public UsersViewModel() : this(new Registration()) { }

        public RelayCommand<IUser> AddUser => GetCommand((ExecuteHandler<IUser>)_registration.AddUser);

        public RelayCommand<IUser> UpdateUser => GetCommand((ExecuteHandler<IUser>)_registration.UpdateUser);

        public RelayCommand<IUser> RemoveUser => GetCommand((ExecuteHandler<IUser>)_registration.RemoveUser);

        public override string ToString()
        {
            return "Сотрудники";
        }
    }
}
