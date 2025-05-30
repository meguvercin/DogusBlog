using DogusBlog.Data.Abstract;
using DogusBlog.Data.Concrete.EfCore;
using DogusBlog.Entity;

namespace DogusBlog.Data.Concrete
{

    public class EfPostRepository : IPostRepository
    {
        private BlogContext _context;
        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        public void EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault(i => i.PostId == post.PostId);

            if (entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.Url = post.Url;
                entity.IsActive = post.IsActive;

                _context.SaveChanges();
            }
        }
        public void DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }


    }
}