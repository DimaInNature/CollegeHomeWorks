using System.Data.Entity;
using Work4.Models;

namespace Work4.Data.Context
{
    public class StructuralDivisionContext : BaseContext
    {
        public StructuralDivisionContext() : base() { }

        public DbSet<StructuralDivision> StructuralDivisions { get; set; }
    }
}
