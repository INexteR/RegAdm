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
using ViewModels;
using ViewModels.Interfaces;

namespace RegAdm.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для UserDialog.xaml
    /// </summary>
    internal partial class UserDialog : UserDialogBase
    {
        private UserDialog(TempUser user, IUsersViewModel viewModel) : base(user, viewModel)
        {
            
        }

        public static void Add(IUsersViewModel viewModel)
        {
            var window = new UserDialog(new TempUser(), viewModel)
            {
                Title = "Добавление сотрудника"
            };
            window.title.Text = "Заполните данные о сотруднике";
            window.button.Command = new RelayCommand<TempUser>(window.AddExecute, AddUpdateCanExecute);
            window.ShowDialog();           
        }

        private void AddExecute(TempUser user)
        {
            dialogData.ViewModel.AddUser.Execute(user);
            Close();
        }

        private static bool AddUpdateCanExecute(TempUser user) => !user.HasErrors;

        public static void Update(TempUser user, IUsersViewModel viewModel)
        {
            var window = new UserDialog(user, viewModel)
            {
                Title = "Редактирование данных сотрудника"
            };
            window.title.Text = "Отредактируйте данные сотрудника";
            window.button.Command = new RelayCommand<TempUser>(window.UpdateExecute, AddUpdateCanExecute);
            window.ShowDialog();
        }

        private void UpdateExecute(TempUser user)
        {
            dialogData.ViewModel.UpdateUser.Execute(user);
            Close();
        }
    }
}
