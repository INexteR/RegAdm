using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("users")]
    public partial class User : IUser
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string Role { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}


