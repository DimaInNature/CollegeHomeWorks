using System;
using System.Collections.Generic;
using System.Linq;
using Work5.Models.Context;

namespace Work5.Models.Repository
{
    public class SQLPostRepository : IRepository<Post>
    {
        public SQLPostRepository()
        {
            _db = new PostContext();
        }

        private readonly PostContext _db;
        private bool _disposed;

        public void Create(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
        }

        public IEnumerable<Post> Read() => _db.Posts;

        public Post Read(int id) => _db.Posts
            .FirstOrDefault(post => post.Id == id);

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