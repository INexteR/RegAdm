using ViewModels;

namespace RegAdmViewModels
{
    public class LoginPassword : ValidationBase
    {
        public LoginPassword()
        {
            Login = /*string.Empty*/"Dan323x021@yandex.com";
            Password =/* string.Empty*/"dns73bhs3";
        }

        public string Login
        {
            get => Get<string>()!;
            set => Set(value ?? string.Empty);
        }

        public string Password
        {
            get => Get<string>()!;
            set => Set(value ?? string.Empty);
        }

        const string loginError = "Введите логин";
        const string passwordError = "Введите пароль";


        protected override void OnPropertyChanged(string propertyName, object? oldValue, object? newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
            ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(Login):
                    string? login = (string?)newValue;
                    if (string.IsNullOrWhiteSpace(login))
                        AddError(loginError, propertyName);
                    break;
                case nameof(Password):
                    string? password = (string?)newValue;
                    if (string.IsNullOrWhiteSpace(password))
                        AddError(passwordError, propertyName);
                    break;
            }
        }
    }

}
