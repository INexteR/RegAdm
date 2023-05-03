using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdm
{
    public class Locator : ViewModelBase
    {
        public IAuthorizationViewModel Authorization
        {
            get => Get<IAuthorizationViewModel>()!;
            set => Set(value);
        }

        public IUsersViewModel UsersViewModel
        {
            get => Get<IUsersViewModel>()!;
            set => Set(value);
        }

        public IRoomsViewModel RoomsViewModel
        {
            get => Get<IRoomsViewModel>()!;
            set => Set(value);
        }

        public IClientsViewModel ClientsViewModel
        {
            get => Get<IClientsViewModel>()!;
            set => Set(value);
        }

        public IReservationsViewModel ReservationsViewModel
        {
            get => Get<IReservationsViewModel>()!;
            set => Set(value);
        }
    }
}
