using RegAdmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace RegAdm.Dialogs
{
    internal class ReservationDialogBase : AddUpdateDialog<TempReservation, IReservationsViewModel>
    {
        protected ReservationDialogBase(TempReservation reservation, IReservationsViewModel viewModel) : base(reservation, viewModel)
        {
        }
    }

    internal class ReservationDialogData : AddUpdateDialogData<TempReservation, IReservationsViewModel>
    {

    }
}
