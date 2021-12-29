using System.Data.Entity;
using Work5.Models.Base;

namespace Work5.Models.Context
{
    public class MovementLogContext : BaseContext
    {
        public MovementLogContext() : base() { }

        public DbSet<MovementLog> MovementLogs { get; set; }
    }
}