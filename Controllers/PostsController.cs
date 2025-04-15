using System.Security.Claims;
using System.Threading.Tasks;
using DogusBlog.Data.Abstract;
using DogusBlog.Entity;
using DogusBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogusBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRrepository;
        private readonly ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRrepository, ICommentRepository commentRepository)
        {
            _postRrepository = postRrepository;
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRrepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }

            return View(new PostViewModel { Posts = await posts.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            var post = await _postRrepository.Posts
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(p => p.Url == url);

            return View(post);
        }

        [HttpPost]
        public JsonResult AddComment(int PostId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                PostId = PostId,
                UserId = int.Parse(userId ?? "0")
            };

            _commentRepository.CreateComment(entity);

            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateViewModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

                var post = new Post
                {
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url,
                    UserId = userId,
                    PublishedOn = DateTime.Now,
                    IsActive = true
                };

                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                    post.Image = fileName;
                }

                post.Tags = GenerateTagsFromPost(post); // ← otomatik etiket ekleme
                _postRrepository.CreatePost(post);

                TempData["Message"] = "Gönderi başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var role = User.FindFirstValue(ClaimTypes.Role);
            var posts = _postRrepository.Posts;

            if (role != "admin")
            {
                posts = posts.Where(p => p.UserId == userId);
            }

            return View(await posts.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var post = _postRrepository.Posts.FirstOrDefault(p => p.PostId == id);
            if (post == null || (role != "admin" && post.UserId != userId))
                return Unauthorized();

            return View(new PostCreateViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                Url = post.Url,
                IsActive = post.IsActive,
                Image = post.Image
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(PostCreateViewModel model, IFormFile? ImageFile, bool removeImage = false)
        {
            // Clear ImageFile validation if it's null
            if (ImageFile == null)
            {
                ModelState.Remove("ImageFile");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = await _postRrepository.Posts.FirstOrDefaultAsync(p => p.PostId == model.PostId);
            if (post == null) return NotFound();

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var role = User.FindFirstValue(ClaimTypes.Role);

            if (post.UserId != userId && role != "admin")
                return Unauthorized();

            // Update basic fields
            post.Title = model.Title;
            post.Description = model.Description;
            post.Content = model.Content;
            post.Url = model.Url;
            post.IsActive = model.IsActive;

            // Handle image upload or removal
            if (removeImage)
            {
                // Remove existing image
                if (!string.IsNullOrEmpty(post.Image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", post.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    post.Image = null;
                }
            }
            else if (ImageFile != null && ImageFile.Length > 0)
            {
                // Delete old image if exists
                if (!string.IsNullOrEmpty(post.Image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", post.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Save new image
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                post.Image = fileName;
            }

            try
            {
                _postRrepository.EditPost(post);
                TempData["Message"] = "Gönderi başarıyla güncellendi.";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Gönderi güncellenirken bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentRepository.Comments
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.CommentId == id);

            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdStr)) return RedirectToAction("Login");
            int userId = int.Parse(userIdStr);

            if (comment != null && comment.UserId == userId)
            {
                _commentRepository.DeleteComment(comment);
                TempData["Message"] = "Yorum başarıyla silindi.";
            }

            return RedirectToAction("Details", new { url = comment?.Post?.Url });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
            var role = User.FindFirstValue(ClaimTypes.Role);
            var post = _postRrepository.Posts.FirstOrDefault(p => p.PostId == id);

            if (post == null)
                return NotFound();

            if (post.UserId != userId && role != "admin")
                return Unauthorized();

            _postRrepository.DeletePost(id);
            TempData["Message"] = "Gönderi başarıyla silindi.";
            return RedirectToAction("List");
        }
        private List<Tag> GenerateTagsFromPost(Post post)
        {
            var content = (post.Title + " " + post.Description + " " + post.Content).ToLower();

            // Eşleşmesini istediğimiz anahtar kelimeler
            var keywords = new List<string> {
        "web programlama", "backend", "frontend", "game", "fullstack"
    };

            var tags = new List<Tag>();

            var allTags = _postRrepository.GetAllTags(); // Aşağıda adım 2'de tanımlayacağız

            foreach (var keyword in keywords)
            {
                if (content.Contains(keyword.ToLower()))
                {
                    var matchedTag = allTags.FirstOrDefault(t => t.Text!.ToLower() == keyword.ToLower());
                    if (matchedTag != null && !tags.Any(x => x.TagId == matchedTag.TagId))
                    {
                        tags.Add(matchedTag);
                    }
                }
            }

            return tags;
        }

    }

}
