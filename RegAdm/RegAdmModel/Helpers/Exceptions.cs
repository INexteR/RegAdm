using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegAdmModel.Helpers
{
    internal class Exceptions
    {
        public static NotImplementedException NotImplemented { get; } = new();

        public static void ThrowIfIdNotZero(IIdEntity entity)
        {
            if (entity.Id != 0)
            {
                throw new ArgumentException("Id имело значение, отличное от 0");
            }
        }
    }
}
