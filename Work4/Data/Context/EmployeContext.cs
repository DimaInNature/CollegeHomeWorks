using System.Data.Entity;
using Work4.Models;

namespace Work4.Data.Context
{
    public class EmployeContext : BaseContext
    {
        public EmployeContext() : base() { }

        public DbSet<Employe> Employees { get; set; }
    }
}
