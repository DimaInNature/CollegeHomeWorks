using System.Data.Entity;

namespace Work5.Models.Base
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext() : base(_connection) { }

        private static readonly string _connection = "DB10";
    }
}