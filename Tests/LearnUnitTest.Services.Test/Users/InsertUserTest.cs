using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LearnUnitTest.Services.Test.Users
{
    public class InsertUserTest
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserService _userService;

        private List<User> _userDataSource;

        public InsertUserTest()
        {
            _userDataSource = new List<User>();

            var mockUserRepository = new Mock<IRepository<User>>();
            mockUserRepository.Setup(r => r.Insert(It.IsNotNull<User>())).Callback((User user) => _userDataSource.Add(user));
            mockUserRepository.SetupGet(r => r.Table).Returns(_userDataSource.AsQueryable());

            _userRepository = mockUserRepository.Object;
            _userService = new UserService(_userRepository);
        }

        [Fact]
        public void When_user_is_null_throws_exception()
        {
            // Arrange
            User user = null;

            // Act


            // Assert
            Assert.Throws<ArgumentNullException>(() => _userService.InsertUser(user));
        }

        [Fact]
        public void User_successfully_insert_and_can_be_find()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "admin",
                Password = "Pa$$w0rd"
            };

            // Act
            _userService.InsertUser(user);

            // Assert
            Assert.Contains(user, _userDataSource);
        }
    }
}