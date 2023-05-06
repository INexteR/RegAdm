using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Seria { get; set; }

        public string Number { get; set; }

        public string Phone { get; set; }

        public ClientDTO(int id, string fullName, DateOnly birthDate, string seria, string number, string phone)
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
