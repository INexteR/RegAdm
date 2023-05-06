using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class IdProxy<T> : Proxy<T>
    {
        public int Id { get; }

        public IdProxy(int id, T data) : base(data)
        {
            Id = id;
        }
    }
}
