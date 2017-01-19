using LearnUnitTest.Core.Domain.Users;
using System.Collections.Generic;

namespace LearnUnitTest.Services.Test.Users
{
    public class UserDataSourceFactory
    {
        public static List<User> Create()
        {
            return new List<User>
            {
                new User { Id = 1, Username ="admin", Password = "Pa$$w0rd" },
                new User { Id = 2, Username ="supervisor", Password = "123456" },
                new User { Id = 3, Username ="zhangsan", Password = "1111" }
            };
        }
    }
}
