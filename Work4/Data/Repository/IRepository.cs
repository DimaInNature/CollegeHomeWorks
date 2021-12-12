using System;
using System.Collections.Generic;

namespace Work4.Data
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        T Read(int id);
        IEnumerable<T> Read();
        void Create(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}
