namespace DogusBlog.Data.Concrete.EfCore
{
    using System.Linq;
    using DogusBlog.Data.Abstract;
    using DogusBlog.Entity;
    using Microsoft.EntityFrameworkCore;

    public class EfTagRepository : ITagRepository
    {
        private BlogContext _context;

        public EfTagRepository(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Tag> Tags => _context.Tags;

        public void CreateTag(Tag Tag)
        {
            _context.Tags.Add(Tag);
            _context.SaveChanges();
        }
    }
}