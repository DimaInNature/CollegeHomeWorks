using System.Data.Entity;

namespace Work4.Data.Context
{
    public abstract class BaseContext : DbContext
    {
        public BaseContext() : base(_connection) { }

        private static readonly string _connection = "DB3";
    }
}
