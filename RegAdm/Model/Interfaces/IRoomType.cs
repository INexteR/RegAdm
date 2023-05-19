using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IRoomType : IIdEntity
    {
        string Name { get; } 

        sbyte Places { get; }

        int PricePerDay { get; }

        IEnumerable<IRoom> Rooms { get; }
    }
}
