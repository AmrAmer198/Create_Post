using Create_Post.Models;
using DAL.Entity;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Create_Post.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly PostRepositroy _postRepository;

        public HomeController(PostRepositroy postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View(_postRepository.GetAllPosts());
        }

        [HttpPost]
        public IActionResult Create(string postDetails)
        {
            var post = new Post { PostDetails = postDetails };
            _postRepository.AddPost(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(int id, string postDetails)
        {
            var post = _postRepository.GetPostById(id);
            if (post != null)
            {
                post.PostDetails = postDetails;
                _postRepository.UpdatePost(post);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _postRepository.DeletePost(id);
            return RedirectToAction("Index");
        }
    }

}