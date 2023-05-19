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
    /// Логика взаимодействия для ClientDialog.xaml
    /// </summary>
    internal partial class ClientDialog : ClientDialogBase
    {
        private ClientDialog(TempClient client, IClientsViewModel viewModel) : base(client, viewModel)
        {
            InitializeComponent();
        }

        public static void Add(IClientsViewModel viewModel)
        {
            var window = new ClientDialog(new TempClient(), viewModel)
            {
                Title = "Добавление клиента"
            };
            window.title.Text = "Заполните данные о клиенте";
            window.button.Command = new RelayCommand<TempClient>(window.AddExecute, AddUpdateCanExecute);
            window.ShowDialog();
        }

        private void AddExecute(TempClient client)
        {
            dialogData.ViewModel.AddClient.Execute(client);
            Close();
        }

        private static bool AddUpdateCanExecute(TempClient client) => !client.HasErrors;

        public static void Update(TempClient client, IClientsViewModel viewModel)
        {
            var window = new ClientDialog(client, viewModel)
            {
                Title = "Редактирование данных сотрудника"
            };
            window.title.Text = "Отредактируйте данные сотрудника";
            window.button.Command = new RelayCommand<TempClient>(window.UpdateExecute, AddUpdateCanExecute);
            window.ShowDialog();
        }

        private void UpdateExecute(TempClient client)
        {
            dialogData.ViewModel.UpdateClient.Execute(client);
            Close();
        }
    }
}
