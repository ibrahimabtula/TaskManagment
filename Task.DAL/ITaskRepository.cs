
using System.Collections.Generic;

namespace Task.DAL
{
    interface ITaskRepository<T,TCriteria> 
        where TCriteria : ICriteria
    {
        T FetchByID(int ID);
        IEnumerable<T> FetchAll(TCriteria criteria);
        bool Update(T obj);
        bool Insert(T obj);
    }
}
