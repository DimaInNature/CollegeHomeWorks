using System;
using System.Collections.Generic;
using System.Linq;
using Work5.Models.Context;

namespace Work5.Models.Repository
{
    public class SQLMovementLogRepository : IRepository<MovementLog>
    {
        public SQLMovementLogRepository()
        {
            _db = new MovementLogContext();
        }

        private readonly MovementLogContext _db;
        private bool _disposed;

        public void Create(MovementLog log)
        {
            _db.MovementLogs.Add(log);
            _db.SaveChanges();
        }

        public IEnumerable<MovementLog> Read() => _db.MovementLogs;

        public MovementLog Read(int id) => _db.MovementLogs
            .FirstOrDefault(log => log.Id == id);

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