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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Interfaces;

namespace RegAdm.Views
{
    /// <summary>
    /// Логика взаимодействия для ReservationsView.xaml
    /// </summary>
    public partial class ReservationsView : UserControl
    {
        public ReservationsView()
        {
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            //UserDialog.Add((IReservationsViewModel)DataContext);
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            //var reservationDto = ((ReservationProxy)((Button)sender).DataContext).Data;

            //UserDialog.Update(new TempUser(reservationDto.Id, userDto.FullName, userDto.BirthDate, userDto.Role, userDto.Login, userDto.Password),
            //    (IReservationsViewModel)DataContext);
        }
    }
}
