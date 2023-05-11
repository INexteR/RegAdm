using Model;
using Model.DTOs;
using Model.Interfaces;
using System.Windows.Input;

namespace ViewModels.Interfaces
{
    public interface IAuthorizationViewModel
    {
        AuthorizationStatus CurrentStatus { get; }

        UserDto? CurrentUser { get; }

        RelayCommand Authorize { get; }

        RelayCommand Exit { get; }
    }

}
