using System;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IAuthorization
    {
        AuthorizationStatus Status { get; }

        IUser? CurrentUser { get; }

        void Authorize(string login, string password);

        Task AuthorizeAsync(string login, string password);

        void Exit();

        event EventHandler<AuthorizationChangedArgs> AuthorizationChanged;
    }
}
