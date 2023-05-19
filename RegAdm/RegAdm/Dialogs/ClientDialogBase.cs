using RegAdmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace RegAdm.Dialogs
{
    internal class ClientDialogBase : AddUpdateDialog<TempClient, IClientsViewModel>
    {
        protected ClientDialogBase(TempClient client, IClientsViewModel viewModel) : base(client, viewModel)
        {
        }
    }

    internal class ClientDialogData : AddUpdateDialogData<TempClient, IClientsViewModel>
    {

    }
}
