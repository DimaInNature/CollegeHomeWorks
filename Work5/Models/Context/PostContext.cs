using System.Data.Entity;
using Work5.Models.Base;

namespace Work5.Models.Context
{
    public class PostContext : BaseContext
    {
        public PostContext() : base() { }

        public DbSet<Post> Posts { get; set; }
    }
}