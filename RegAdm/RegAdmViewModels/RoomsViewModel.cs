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

namespace RegAdmViewModels
{
    public class RoomsViewModel : ViewModelBase, IRoomsViewModel
    {
        private readonly ObservableCollection<IRoomType> roomTypes;
        public IEnumerable<IRoomType> RoomTypes => roomTypes;

        private readonly ObservableCollection<IRoom> rooms;
        public IEnumerable<IRoom> Rooms => rooms;

        public RoomsViewModel(IRegistration registration)
        {
            roomTypes = new ObservableCollection<IRoomType>(registration.RoomTypes);
            rooms = new ObservableCollection<IRoom>(registration.Rooms);
            registration.SourcesLoaded += OnSourcesLoaded;
        }

        private void OnSourcesLoaded(object? sender, EventArgs e)
        {
            var registration = (IRegistration)sender!;
            roomTypes.Reset(registration.RoomTypes);
            rooms.Reset(registration.Rooms);
        }

        public RoomsViewModel() : this(new Registration()) { }

        public override string ToString()
        {
            return "Комнаты";
        }
    }
}
