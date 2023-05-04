using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace RegAdm.Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView()
        {
            InitializeComponent();
            Locator locator = (Locator)FindResource(nameof(locator));
            var add = tables.Items.Add;
            if (locator.Authorization.CurrentUser.Role is Helper.SENIOR_ADMINISTRATOR)
            {
                add(locator.UsersViewModel);
            }          
            add(locator.ClientsViewModel);
            add(locator.ReservationsViewModel);
            add(locator.RoomsViewModel);
        }
    }
}
