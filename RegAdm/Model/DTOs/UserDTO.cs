﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class UserDto : IdDto
    {
        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Role { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserDto(int id, string fullName, DateOnly birthDate, string role, string login, string password)
            : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Role = role;
            Login = login;
            Password = password;
        }
    }
}
