using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class Proxy<T> : ViewModelBase
    {
        protected T Data { get; private set; }

        public Proxy(T data) 
        { 
            Data = data; 
        }

        public void SetData(T data)
        {
            OnSetData(data);
            Data = data;
            OnPropertyChanged(AllChanged);
        }

        protected virtual void OnSetData(T newData) { }
    }
}
