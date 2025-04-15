using DogusBlog.Entity;

namespace DogusBlog.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; }
        void CreateTag(Tag Tag);
        
    }
}