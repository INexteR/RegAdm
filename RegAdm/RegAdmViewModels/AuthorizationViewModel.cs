using Model;
using ViewModels;
using Model.Interfaces;
using ViewModels.Interfaces;
using RegAdmModel;
using Model.DTOs;

namespace RegAdmViewModels
{
    public class AuthorizationViewModel : ViewModelBase, IAuthorizationViewModel
    {
        private readonly IAuthorization _authorization;

        #region Прокси-свойства
        public UserDto? CurrentUser => _authorization.CurrentUser;
        public AuthorizationStatus CurrentStatus => _authorization.Status;
        #endregion

        #region Команда авторизированного входа.
        public RelayCommand Authorize => GetCommand<LoginPassword>(AuthorizeExecute, AuthorizeCanExecute);

        private bool AuthorizeCanExecute(LoginPassword loginPassword)
        {
            return !loginPassword.HasErrors && _authorization.Status is AuthorizationStatus.None 
                or AuthorizationStatus.Fail;
        }
        private async void AuthorizeExecute(LoginPassword loginPassword)
        {
            await _authorization.AuthorizeAsync(loginPassword.Login, loginPassword.Password);
        }
        #endregion 

        #region Команда выхода из авторизации.
        public RelayCommand Exit => GetCommand(ExitExecute, ExitCanExecute);

        private bool ExitCanExecute() => _authorization.Status == AuthorizationStatus.Authorized;

        private void ExitExecute() => _authorization.Exit();
        #endregion 

        public AuthorizationViewModel()
            : this(new Registration())
        { }

        public AuthorizationViewModel(IAuthorization authorization)
        {
            _authorization = authorization;
            _authorization.AuthorizationChanged += OnAuthorizationChanged;
        }

        private void OnAuthorizationChanged(object? sender, AuthorizationChangedArgs e)
        {
            RaisePropertyChanged(nameof(CurrentStatus));
            RaisePropertyChanged(nameof(CurrentUser));

            Authorize.RaiseCanExecuteChanged();
            Exit.RaiseCanExecuteChanged();
        }
    }
}
