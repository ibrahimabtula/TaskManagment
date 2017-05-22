using System.Collections.Generic;

namespace Task.DAL
{
    public abstract class AbstractRepository<T, TCrit> where TCrit : ICriteria
    {
        public abstract T Fetch(TCrit criteria);

        public abstract IEnumerable<T> FetchAll(TCrit criteria);

        public abstract void Update(T obj);
    }
}
