using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;
using static RegAdmModel.RegistrationSettings;

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

        public IEnumerable GetTablesForCurrentUser()
        {
            if (Authorization?.CurrentUser is null)
            {
                throw new NotSupportedException();
            }
            if (Authorization.CurrentUser.Role is SENIOR_ADMINISTRATOR)
            {
                yield return UsersViewModel;
            }
            yield return ClientsViewModel;
            yield return ReservationsViewModel;
            yield return RoomsViewModel;
        }
        public bool Design { get; set; }
    }
}
