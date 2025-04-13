using DogusBlog.Data.Abstract;
using DogusBlog.Data.Concrete.EfCore;
using DogusBlog.Entity;
using Microsoft.AspNetCore.Mvc;
using DogusBlog.Models;

namespace DogusBlog.Controllers
{

    public class PostsController : Controller
    {

        private IPostRepository _postRrepository;
        public PostsController(IPostRepository postRrepository)
        {
            _postRrepository = postRrepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var claims = User.Claims;
            var posts = _postRrepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }
            return View(new PostViewModel { Posts = await posts.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRrepository.Posts.Include(x => x.Tags).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefaultAsync(p => p.Url == url));
        }

    }
}