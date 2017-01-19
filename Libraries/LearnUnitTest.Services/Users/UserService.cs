using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using System;
using System.Linq;

namespace LearnUnitTest.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepostory;

        public UserService(IRepository<User> userRepostory)
        {
            _userRepostory = userRepostory;
        }

        public User GetUserByUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                return null;
            }

            return _userRepostory.Table.SingleOrDefault(u => u.Username == username);
        }

        public bool IsUsernameExists(string username)
        {
            return GetUserByUsername(username) != null;
        }

        public void InsertUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _userRepostory.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _userRepostory.Update(user);
        }
    }
}
