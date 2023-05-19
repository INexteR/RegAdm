using RegAdmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels.Interfaces;
using ViewModels;

namespace RegAdm.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для ReservationDialog.xaml
    /// </summary>
    internal partial class ReservationDialog : ReservationDialogBase
    {
        private ReservationDialog(TempReservation reservation, IReservationsViewModel viewModel) : base(reservation, viewModel)
        {
            InitializeComponent();
        }

        public static void Add(IReservationsViewModel viewModel)
        {
            var window = new ReservationDialog(new TempReservation(), viewModel)
            {
                Title = "Добавление бронирования"
            };
            //window.title.Text = "Заполните данные бронирования";
            //window.button.Command = new RelayCommand<TempReservation>(window.AddExecute, AddUpdateCanExecute);
            window.ShowDialog();
        }

        private void AddExecute(TempReservation reservation)
        {
            //var reservationDto = new ReservationDto(0, reservation.BookingDate, reservation.RoomId, reservation.CheckInDate!, reservation.EvictionDate!, reservation.ActualEvictionDate ?? reservation.EvictionDate!, reservation.UserId);
            //dialogData.ViewModel.AddReservation.Execute(reservationDto);
            Close();
        }

        //private static bool AddUpdateCanExecute(TempReservation reservation) => !reservation.HasErrors;

        public static void Update(TempReservation reservation, IReservationsViewModel viewModel)
        {
            var window = new ReservationDialog(reservation, viewModel)
            {
                Title = "Редактирование данных бронирования"
            };
            //window.title.Text = "Отредактируйте данные бронирования";
            //window.button.Command = new RelayCommand<TempReservation>(window.UpdateExecute, AddUpdateCanExecute);
            window.ShowDialog();
        }

        private void UpdateExecute(TempReservation reservation)
        {
            //var reservationDto = new ReservationDto(reservation.Id, reservation.BookingDate, reservation.RoomId, reservation.CheckInDate!, reservation.EvictionDate!, reservation.ActualEvictionDate ?? reservation.EvictionDate!, reservation.UserId);
            //dialogData.ViewModel.UpdateReservation.Execute(reservationDto);
            Close();
        }
    }
}
