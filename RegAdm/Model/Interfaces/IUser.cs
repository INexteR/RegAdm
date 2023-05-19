using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IUser : IIdEntity
    {
        string FullName { get; }

        DateOnly BirthDate { get; }

        string Role { get; }

        string Login { get; }

        string Password { get; }

        IEnumerable<IReservation> Reservations { get; }
    }
}
