using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Proxies
{
    public class UserProxy : IdProxy<UserDto>
    {
        public string FullName => Data.FullName;

        public DateOnly BirthDate => Data.BirthDate;

        public string Role => Data.Role;

        public string Login => Data.Login;

        public string Password => Data.Password;

        public UserProxy(UserDto user) : base(user.Id, user) { }
    }
}
