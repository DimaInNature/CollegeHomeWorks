using System.Data.Entity;
using Work4.Models;

namespace Work4.Data.Context
{
    public class PostContext : BaseContext
    {
        public PostContext() : base() { }

        public DbSet<Post> Posts { get; set; }
    }
}
