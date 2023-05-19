using System;
using Model.Interfaces;

namespace Model
{
    public class AuthorizationChangedArgs : EventArgs
    {
        public AuthorizationStatus NewStatus { get; }

        public IUser? NewUser { get; }

        public AuthorizationChangedArgs(AuthorizationStatus newStatus, IUser? newUser = null)
        {
            if (!Enum.IsDefined(newStatus))
            {
                throw new ArgumentException("Неожиданное значение.", nameof(newStatus));
            }

            if (newStatus is AuthorizationStatus.InProcessing or AuthorizationStatus.None 
                && newUser is not null)
            {
                throw new ArgumentException($"Допустимо только для {AuthorizationStatus.Authorized}.", 
                    nameof(newUser));
            }

            NewStatus = newStatus;
            NewUser = newUser;
        }
    }
}
