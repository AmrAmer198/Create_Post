using DAL.Database;
using DAL.Entity;
using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PostRepositroy : IPost
    {

        private ApplicationDbContext _Context { get; set; }

        public PostRepositroy(ApplicationDbContext Context)
        {
            this._Context = Context;
        }
        public IEnumerable<Post> GetAllPost()
        {
            return _Context.Posts.ToList();
        }

        public Post GetPostById(int Id)
        {
            return _Context.Posts.Find(Id);
        }

        public void InsertPost(Post post)
        {
            _Context.Posts.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _Context.Entry(post).State = EntityState.Modified;

        }
    }
}
