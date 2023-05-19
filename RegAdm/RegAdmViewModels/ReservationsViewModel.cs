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
    public class ReservationsViewModel : ViewModelBase, IReservationsViewModel
    {
        private readonly IRegistration _registration;
        private readonly ObservableCollection<IReservation> reservations;

        public IEnumerable<IReservation> Reservations => reservations;

        public ReservationsViewModel(IRegistration registration)
        {
            _registration = registration;
            reservations = new(_registration.Reservations);
            _registration.ReservationChanged += OnEntityChanged;
        }

        private void OnEntityChanged(IRegistration source, ActionChanges action, IReservation old, IReservation @new)
        {
            switch (action)
            {
                case ActionChanges.Remove: throw new NotSupportedException();
                default:
                    reservations.ReplaceOrAdd(@new, (r1, r2) => r1.Id == r2.Id);
                    break;
            }
        }

        public ReservationsViewModel() : this(new Registration()) { }

        public RelayCommand<IReservation> AddReservation => GetCommand((ExecuteHandler<IReservation>)_registration.AddReservation);

        public RelayCommand<IReservation> UpdateReservation => GetCommand((ExecuteHandler<IReservation>)_registration.UpdateReservation);

        public override string ToString()
        {
            return "Бронирования";
        }
    }
}
