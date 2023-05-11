using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("users")]
    internal partial class User
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string Role { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public User() { }
        public User(int id, string fullName, DateOnly birthDate, string role, string login, string password)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Role = role;
            Login = login;
            Password = password;
        }
    }
}


