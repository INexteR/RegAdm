using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ISupportDbOperation<TDTO>
    {
        IEnumerable<TDTO> Entities { get; }
        void Add(TDTO entity);
        void Remove(TDTO entity);
        void Update(TDTO entity);
    }
}
