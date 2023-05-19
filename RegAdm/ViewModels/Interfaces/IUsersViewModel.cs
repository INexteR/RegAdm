using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Interfaces;

namespace ViewModels.Interfaces
{
    public interface IUsersViewModel
    {
        IEnumerable<IUser> Users { get; }

        RelayCommand<IUser> AddUser { get; }

        RelayCommand<IUser> UpdateUser { get; }

        RelayCommand<IUser> RemoveUser { get; }
    }
}
