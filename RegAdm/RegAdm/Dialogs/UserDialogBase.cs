using RegAdmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace RegAdm.Dialogs
{
    internal class UserDialogBase : AddUpdateDialog<TempUser, IUsersViewModel>
    {
        protected UserDialogBase(TempUser user, IUsersViewModel viewModel) : base(user, viewModel)
        {
        }
    }

    internal class UserDialogData : AddUpdateDialogData<TempUser, IUsersViewModel>
    {

    }
}
