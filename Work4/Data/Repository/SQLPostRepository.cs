using System;
using System.Collections.Generic;
using System.Linq;
using Work4.Data.Context;
using Work4.Models;

namespace Work4.Data.Repository
{
    public class SQLPostRepository : IRepository<Post>
    {
        public SQLPostRepository()
        {
            _db = new PostContext();
        }

        private readonly PostContext _db;

        private bool _disposed = false;

        public void Create(Post post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
        }

        public Post Read(int id) =>
            _db.Posts.FirstOrDefault(post => post.Id == id);
      
        public IEnumerable<Post> Read() => _db.Posts;
        
        public bool Update(Post post)
        {
            var contextRecord = _db.Posts.Find(post.Id);

            if(post != null && contextRecord != null)
            {
                _db.Posts.Attach(contextRecord);

                (contextRecord.Name, contextRecord.Wage) = (post.Name, post.Wage);

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Post post)
        {
            var postCheck = _db.Posts.Find(post.Id);

            if(postCheck != null)
            {
                _db.Posts.Remove(post);

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

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
