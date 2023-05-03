using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdmViewModels
{
    public class ReservationsViewModel : ViewModelBase, IReservationsViewModel
    {
        public override string ToString()
        {
            return "Бронирования";
        }
    }
}
