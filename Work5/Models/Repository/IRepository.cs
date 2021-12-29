using System;
using System.Collections.Generic;

namespace Work5.Models.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Create(T item);
        IEnumerable<T> Read();
        T Read(int id);
    }
}
