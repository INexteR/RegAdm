using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdmViewModels
{
    public class ClientsViewModel : ViewModelBase, IClientsViewModel
    {
        public override string ToString()
        {
            return "Клиенты";
        }
    }
}
