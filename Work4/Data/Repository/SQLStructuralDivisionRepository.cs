using System;
using System.Collections.Generic;
using System.Linq;
using Work4.Data.Context;
using Work4.Models;

namespace Work4.Data.Repository
{
    public class SQLStructuralDivisionRepository : IRepository<StructuralDivision>
    {
        public SQLStructuralDivisionRepository()
        {
            _db = new StructuralDivisionContext();
        }

        private readonly StructuralDivisionContext _db;

        private bool _disposed = false;

        public void Create(StructuralDivision division)
        {
            _db.StructuralDivisions.Add(division);
            _db.SaveChanges();
        }

        public StructuralDivision Read(int id) =>
            _db.StructuralDivisions.FirstOrDefault(division => division.Id == id);

        public IEnumerable<StructuralDivision> Read() => _db.StructuralDivisions;

        public bool Update(StructuralDivision division)
        {
            var contextRecord = _db.StructuralDivisions.Find(division.Id);

            if (division != null && contextRecord != null)
            {
                _db.StructuralDivisions.Attach(contextRecord);

                contextRecord.Name = division.Name;

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(StructuralDivision division)
        {
            var divisionCheck = _db.StructuralDivisions.Find(division.Id);

            if(divisionCheck != null)
            {
                _db.StructuralDivisions.Remove(division);

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
