using System.Data.Entity;
using Work4.Models;

namespace Work4.Data.Context
{
    public class MovementLogContext : BaseContext
    {
        public MovementLogContext() : base() { }

        public DbSet<MovementLog> MovementLogs { get; set; }
    }
}
