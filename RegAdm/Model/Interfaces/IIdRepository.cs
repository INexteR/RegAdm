using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTOs;

namespace Model.Interfaces
{
    public enum ActionChanges { Add, Remove, Update }

    public delegate void EntityChangeHandler<T>(IIdRepository<T> source, ActionChanges action, T old, T @new)
        where T : IdDto;

    public interface IIdRepository<T> where T : IdDto
    {
        event EntityChangeHandler<T> EntityChanged;

        IEnumerable<T> GetAll();
        T? Get(int id);

        bool Add(T entity);
        bool Remove(T entity);
        bool Update(T entity);
    }
}
