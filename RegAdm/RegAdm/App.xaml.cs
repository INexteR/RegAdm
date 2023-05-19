using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using RegAdmViewModels;
using RegAdmModel;
using Model;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;

namespace RegAdm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
#pragma warning disable CS8618 
        private Locator locator;
#pragma warning restore CS8618

        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            System.Windows.Forms.Application.EnableVisualStyles();
            locator = (Locator)Resources[nameof(locator)];
            var registration = new Registration();
            locator.Authorization = new AuthorizationViewModel(registration);
            locator.RoomsViewModel = new RoomsViewModel(registration);
            locator.UsersViewModel = new UsersViewModel(registration);
            locator.ClientsViewModel = new ClientsViewModel(registration);
            locator.ReservationsViewModel = new ReservationsViewModel(registration);
            registration.AuthorizationChanged += OnAuthorizationChanged;  

            DispatcherUnhandledException += OnException; 
            await registration.LoadAsync();          
        }

        private void OnAuthorizationChanged(object? sender, AuthorizationChangedArgs e)
        {
            switch (e.NewStatus)
            {
                case AuthorizationStatus.Authorized:
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(ToMenu);
                    break;

                case AuthorizationStatus.None:
                    MainWindow.Title = "Авторизация";
                    MainWindow.Content = locator.Authorization;
                    break;
            }
        }

        private void ToMenu()
        {
            MainWindow.Title = "Главное меню";
            MainWindow.Content = MainWindow.Resources["menu"];
        }

        private void OnException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Exception.Message.Msg("Исключение");
            e.Handled = true;
        }
    }
}
