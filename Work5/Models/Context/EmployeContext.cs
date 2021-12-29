using System.Data.Entity;
using Work5.Models.Base;

namespace Work5.Models.Context
{
    public class EmployeContext : BaseContext
    {
        public EmployeContext() : base() { }

        public DbSet<Employe> Employees { get; set; }
    }
}