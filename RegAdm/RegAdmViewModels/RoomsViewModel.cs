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
        //private readonly IRegistration _registration;

        private readonly ObservableCollection<RoomTypeProxy> roomTypes;
        public IEnumerable<RoomTypeProxy> RoomTypes => roomTypes;

        private readonly ObservableCollection<RoomProxy> rooms;       
        public IEnumerable<RoomProxy> Rooms => rooms;

        public RoomsViewModel(IRegistration registration)
        {
            //_registration = registration;
            roomTypes = new(registration.RoomTypesRepository.GetAll()
                .Select(rt => new RoomTypeProxy(rt)));

            rooms = new(registration.RoomsRepository.GetAll()
                .Select(r => new RoomProxy(r, roomTypes.First(rt => rt.Id == r.RoomTypeId),
                registration.ReservationsRepository.GetReservationsForRoom(r.Id)
                .Sum(r => registration.ClientsRepository.GetClientsForReservation(r.Id).Count()))));
        }

        public RoomsViewModel() : this(new Registration()) { }

        public override string ToString()
        {
            return "Комнаты";
        }
    }
}
