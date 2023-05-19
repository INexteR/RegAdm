using Model;
using Model.Interfaces;
using System.Windows.Input;

namespace ViewModels.Interfaces
{
    public interface IAuthorizationViewModel
    {
        AuthorizationStatus CurrentStatus { get; }

        IUser? CurrentUser { get; }

        RelayCommand Authorize { get; }

        RelayCommand Exit { get; }
    }

}
