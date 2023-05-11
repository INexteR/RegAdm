using Model.DTOs;
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

        public static void ThrowIfIdNotZero(IdDto idDto)
        {
            if (idDto.Id != 0)
            {
                throw new ArgumentException("Id было 0");
            }
        }
    }
}
