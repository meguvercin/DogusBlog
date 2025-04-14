using DogusBlog.Data.Abstract;
using DogusBlog.Data.Concrete.EfCore;
using DogusBlog.Entity;

namespace DogusBlog.Data.Concrete
{

    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _context;
        public EfCommentRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComment(Comment Comment)
        {
            _context.Comments.Add(Comment);
            _context.SaveChanges();
        }
    }
}