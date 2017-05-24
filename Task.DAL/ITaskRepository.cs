using System.Collections.Generic;

namespace Task.DAL
{
    public interface ITaskRepository<T,TCriteria> 
        where TCriteria : ICriteria
    {
        T FetchByID(int ID);
        IEnumerable<T> FetchAll(TCriteria criteria);
        void Update(T obj);
        void Insert(T obj);
        void Delete(int ID);
    }
}
