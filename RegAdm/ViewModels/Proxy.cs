using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Proxy<T> : ViewModelBase
    {
        public T Data 
        { 
            get => Get<T>(string.Empty)!; 
            set
            {
                OnSetData(value);
                Set(value, string.Empty);
            }
        }

        public Proxy(T data)
        {
            Data = data;
        }

        protected virtual void OnSetData(T newData) { }
    }
}
