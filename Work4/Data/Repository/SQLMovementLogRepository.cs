using System;
using System.Collections.Generic;
using System.Linq;
using Work4.Data.Context;
using Work4.Models;

namespace Work4.Data.Repository
{
    public class SQLMovementLogRepository : IMovementLogRepository
    {
        public SQLMovementLogRepository()
        {
            _db = new MovementLogContext();
        }

        private readonly MovementLogContext _db;

        private bool _disposed = false;

        public void Create(MovementLog log)
        {
            _db.MovementLogs.Add(log);
            _db.SaveChanges();
        }

        public MovementLog Read(int id) =>
            _db.MovementLogs.FirstOrDefault(log => log.Id == id);

        public IEnumerable<MovementLog> Read() => _db.MovementLogs;

        public bool Update(MovementLog log)
        {
            var contextRecord = _db.MovementLogs.Find(log.Id);

            if (log != null && contextRecord != null)
            {
                _db.MovementLogs.Attach(contextRecord);

                (contextRecord.EmployeId, contextRecord.StructuralDivisionId, contextRecord.PostId, contextRecord.Rate,
                    contextRecord.Salary, contextRecord.DateOfEmployment, contextRecord.OrderNumber, contextRecord.WorkStatus) =
                    (log.EmployeId, log.StructuralDivisionId, log.PostId, log.Rate, log.Salary, log.DateOfEmployment,
                    log.OrderNumber, log.WorkStatus);

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(MovementLog log)
        {
            var movementLogCheck = _db.MovementLogs.Find(log.Id);

            if(movementLogCheck != null)
            {
                _db.MovementLogs.Remove(log);

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
            var log = _db.MovementLogs.FirstOrDefault(l => l.EmployeId == employe.Id);

            if(log != null)
            {
                _db.MovementLogs.Remove(log);

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Post post)
        {
            var log = _db.MovementLogs.FirstOrDefault(l => l.PostId == post.Id);

            if (log != null)
            {
                _db.MovementLogs.Remove(log);

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
            var log = _db.MovementLogs.FirstOrDefault(l => l.StructuralDivisionId == division.Id);

            if (log != null)
            {
                _db.MovementLogs.Remove(log);

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
