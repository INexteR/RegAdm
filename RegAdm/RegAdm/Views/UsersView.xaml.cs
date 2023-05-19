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
using RegAdm.Dialogs;
using ViewModels.Interfaces;
using RegAdmViewModels;
using Forms = System.Windows.Forms;
using Model.Interfaces;
using Model.Mapping;

namespace RegAdm.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private IUsersViewModel ViewModel => (IUsersViewModel)DataContext;

        public UsersView()
        {
            InitializeComponent();
            _ = ViewModel.Users; //исключение!
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            UserDialog.Add(ViewModel);
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            var user = (IUser)((Button)sender).DataContext;

            UserDialog.Update(user.Create<TempUser>(), ViewModel);
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            var ok = new Forms.TaskDialogButton("Уволить");
            var page = new Forms.TaskDialogPage
            {
                Caption = "Подтверждение действия",
                Text = "Действительно уволить сотрудника?", 
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
