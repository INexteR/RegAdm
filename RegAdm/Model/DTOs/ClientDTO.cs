using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ClientDto : IdDto
    {
        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Seria { get; set; }

        public string Number { get; set; }

        public string Phone { get; set; }

        public ClientDto(int id, string fullName, DateOnly birthDate, string seria, string number, string phone)
            : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Seria = seria;
            Number = number;
            Phone = phone;
        }
    }
}
