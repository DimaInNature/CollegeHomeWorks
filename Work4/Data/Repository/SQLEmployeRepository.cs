using System;
using System.Collections.Generic;
using System.Linq;
using Work4.Data.Context;
using Work4.Models;

namespace Work4.Data.Repository
{
    public class SQLEmployeRepository : IRepository<Employe>
    {
        public SQLEmployeRepository()
        {
            _db = new EmployeContext();
        }

        private readonly EmployeContext _db;

        private bool _disposed = false;

        public void Create(Employe employe)
        {
            _db.Employees.Add(employe);
            _db.SaveChanges();
        }

        public Employe Read(int id) =>
            _db.Employees.FirstOrDefault(employe => employe.Id == id);
        
        public IEnumerable<Employe> Read() => _db.Employees;
        
        public bool Update(Employe employe)
        {
            var contextRecord = _db.Employees.Find(employe.Id);

            if (employe != null && contextRecord != null)
            {
                _db.Employees.Attach(contextRecord);

                (contextRecord.Name, contextRecord.Surname, contextRecord.Patronymic, contextRecord.Gender,
                    contextRecord.Address, contextRecord.BirthDay) =
                    (employe.Name, employe.Surname, employe.Patronymic, employe.Gender, employe.Address, employe.BirthDay);

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Employe employe)
        {
            var employeCheck = _db.Employees.Find(employe.Id);

            if(employeCheck != null)
            {
                _db.Employees.Remove(employe);
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

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
