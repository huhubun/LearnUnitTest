using LearnUnitTest.Core.Domain.Users;

namespace LearnUnitTest.Services.Users
{
    public interface IUserService
    {
        User GetUserByUsername(string username);

        bool IsUsernameExists(string username);

        void InsertUser(User user);

        void UpdateUser(User user);
    }
}