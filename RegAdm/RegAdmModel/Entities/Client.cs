using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegAdmModel.Entities
{
    [Table("clients")]
    internal partial class Client : IClient
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        [StringLength(4)]
        public string Seria { get; set; } = null!;

        [StringLength(6)]
        public string Number { get; set; } = null!;

        [StringLength(11)]
        public string Phone { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        IEnumerable<IReservation> IClient.Reservations => Reservations;
        public Client() { }
        public Client(int id, string fullName, DateOnly birthDate, string seria, string number, string phone)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Seria = seria;
            Number = number;
            Phone = phone;
        }
    }
}

