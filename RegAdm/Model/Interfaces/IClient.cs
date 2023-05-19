using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IClient : IIdEntity
    {
        string FullName { get; }

        DateOnly BirthDate { get; }

        string Seria { get; }

        string Number { get; } 

        string Phone { get; }

        IEnumerable<IReservation> Reservations { get; }
    }
}
