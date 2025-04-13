using DogusBlog.Data.Abstract;
using DogusBlog.Data.Concrete.EfCore;
using DogusBlog.Entity;
using Microsoft.AspNetCore.Mvc;
using DogusBlog.Models;

namespace DogusBlog.Controllers
{


    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            return View(
                new PostViewModel
                {
                    Posts = _postRepository.Posts.ToList(),
                }
            );
        }
    }
}