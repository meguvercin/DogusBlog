namespace DogusBlog.Data.Concrete.EfCore
{
    using System.Linq;
    using DogusBlog.Data.Abstract;
    using DogusBlog.Entity;
    using Microsoft.EntityFrameworkCore;

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
    }
}