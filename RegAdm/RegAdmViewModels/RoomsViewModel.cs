using Model.DTOs;
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
using ViewModels.Proxies;

namespace RegAdmViewModels
{
    public class RoomsViewModel : ViewModelBase, IRoomsViewModel
    {
        //private readonly IRoomsProvider _roomsProvider;

        public RoomsViewModel(IRoomsProvider roomsProvider)
        {
            //_roomsProvider = roomsProvider;
            _roomTypes = roomsProvider.RoomTypes.ToDictionary(rt => rt.Id, rt => new RoomTypeProxy(rt));
            _rooms = roomsProvider.Rooms.ToDictionary(r => r.Id, r => new RoomProxy(r, _roomTypes));
        }

        public RoomsViewModel() : this(new Registration()) { }

        private readonly IDictionary<int, RoomTypeProxy> _roomTypes;
        private readonly IDictionary<int, RoomProxy> _rooms;

        public IEnumerable<RoomTypeProxy> RoomTypes => _roomTypes.Values;
        public IEnumerable<RoomProxy> Rooms => _rooms.Values;

        public override string ToString()
        {
            return "Комнаты";
        }
    }
}
