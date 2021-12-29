using System;
using System.Collections.Generic;
using System.Linq;
using Work5.Models.Context;

namespace Work5.Models.Repository
{
    public class SQLEmployeRepository : IRepository<Employe>
    {
        public SQLEmployeRepository()
        {
            _db = new EmployeContext();
        }

        private readonly EmployeContext _db;
        private bool _disposed;

        public void Create(Employe employe)
        {
            _db.Employees.Add(employe);
            _db.SaveChanges();
        }

        public IEnumerable<Employe> Read() => _db.Employees;

        public Employe Read(int id) => _db.Employees
            .FirstOrDefault(employe => employe.Id == id);

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}