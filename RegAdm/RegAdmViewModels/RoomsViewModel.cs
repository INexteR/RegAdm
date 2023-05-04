using Model.Interfaces;
using RegAdmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdmViewModels
{
    public class RoomsViewModel : ViewModelBase, IRoomsViewModel
    {
        private readonly IRoomsProvider _roomsProvider;

        public IEnumerable<dynamic> RoomTypes => _roomsProvider.RoomTypes;
        public IEnumerable<dynamic> Rooms => _roomsProvider.Rooms;

        public RoomsViewModel(IRoomsProvider roomsProvider)
        {
            _roomsProvider = roomsProvider;
        }

        public RoomsViewModel() : this(new Registration()) { }

        public override string ToString()
        {
            return "Комнаты";
        }
    }
}
