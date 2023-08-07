using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IPost
    {
        IEnumerable<Post> GetAllPost();
        Post GetPostById(int Id);
        void InsertPost(Post post);
        void UpdatePost(Post post);
    }
}
