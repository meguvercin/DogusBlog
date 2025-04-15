using DogusBlog.Entity;

namespace DogusBlog.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        void CreatePost(Post post);
        void EditPost(Post post);
        void DeletePost(int id);
        List<Tag> GetAllTags();

    }
}