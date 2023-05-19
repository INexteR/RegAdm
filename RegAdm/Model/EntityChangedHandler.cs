using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum ActionChanges { Add, Remove, Update }

    public delegate void EntityChangeHandler<T>(IRegistration source, ActionChanges action, T old, T @new);
}
