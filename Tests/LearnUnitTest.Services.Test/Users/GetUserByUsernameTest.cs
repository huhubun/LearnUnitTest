using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace LearnUnitTest.Services.Test.Users
{
    public class GetUserByUsernameTest
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserService _userService;

        public GetUserByUsernameTest()
        {
            var mockUserRepository = new Mock<IRepository<User>>();
            mockUserRepository.SetupGet(r => r.Table).Returns(UserDataSourceFactory.Create().AsQueryable());

            _userRepository = mockUserRepository.Object;
            _userService = new UserService(_userRepository);
        }

        [Fact]
        public void When_username_is_null_returns_null()
        {
            // Arrange
            string username = null;

            // Act
            var user = _userService.GetUserByUsername(username);

            // Assert
            Assert.Null(user);
        }

        [Fact]
        public void When_username_is_empty_returns_null()
        {
            // Arrange
            var username = String.Empty;

            // Act
            var user = _userService.GetUserByUsername(username);

            // Assert
            Assert.Null(user);
        }

        [Theory]
        [InlineData(1, "admin", "Pa$$w0rd")]
        [InlineData(2, "supervisor", "123456")]
        [InlineData(3, "zhangsan", "1111")]
        public void When_username_find_an_user(int userId, string username, string password)
        {
            // Arrange

            // Act
            var user = _userService.GetUserByUsername(username);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal(username, user.Username);
            Assert.Equal(password, user.Password);
        }

        [Fact]
        public void When_username_can_not_find_user_returns_null()
        {
            // Arrange
            var username = "wangwu";

            // Act
            var user = _userService.GetUserByUsername(username);

            // Assert
            Assert.Null(user);
        }
    }
}
