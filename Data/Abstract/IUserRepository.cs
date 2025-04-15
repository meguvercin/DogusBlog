using DogusBlog.Entity;

namespace DogusBlog.Data.Abstract
{

    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User User);
        Task UpdateUser(User user);

    }
}