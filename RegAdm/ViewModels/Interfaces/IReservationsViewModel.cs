using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IReservationsViewModel
    {
        IEnumerable<IReservation> Reservations { get; }

        RelayCommand<IReservation> AddReservation { get; }

        RelayCommand<IReservation> UpdateReservation { get; }
    }
}
