using DogusBlog.Entity;

namespace DogusBlog.Data.Abstract
{

    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        void CreateComment(Comment Comment);
    }
}