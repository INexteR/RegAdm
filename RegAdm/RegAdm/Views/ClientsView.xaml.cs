using RegAdm.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.Interfaces;
using Model.Interfaces;
using Forms = System.Windows.Forms;
using Model.Mapping;

namespace RegAdm.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        private IClientsViewModel ViewModel => (IClientsViewModel)DataContext;
        public ClientsView()
        {
            InitializeComponent();
            _ = ViewModel.Clients; //исключение
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            ClientDialog.Add(ViewModel);
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            var client = (IClient)((Button)sender).DataContext;

            ClientDialog.Update(client.Create<TempClient>(), ViewModel);
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            var ok = new Forms.TaskDialogButton("Удалить");
            var page = new Forms.TaskDialogPage
            {
                Caption = "Подтверждение действия",
                Text = "Действительно удалить клиента?",
                Buttons =
                {
                    ok,
                    new Forms.TaskDialogButton("Отмена")
                }
            };
            var button = Forms.TaskDialog.ShowDialog(page, Forms.TaskDialogStartupLocation.CenterScreen);
            if (button == ok)
            {

            }
        }
    }
}
