using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace LearnUnitTest.Services.Test.Users
{
    public class UsernameExistsTest
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserService _userService;

        public UsernameExistsTest()
        {
            var mockUserRepository = new Mock<IRepository<User>>();
            mockUserRepository.SetupGet(r => r.Table).Returns(UserDataSourceFactory.Create().AsQueryable());

            _userRepository = mockUserRepository.Object;
            _userService = new UserService(_userRepository);
        }

        [Fact]
        public void When_username_is_null_returns_false()
        {
            // Arrange
            string username = null;

            // Act
            var isExists = _userService.IsUsernameExists(username);

            // Assert
            Assert.False(isExists);
        }

        [Fact]
        public void When_username_is_empty_returns_false()
        {
            // Arrange
            var username = String.Empty;

            // Act
            var isExists = _userService.IsUsernameExists(username);

            // Assert
            Assert.False(isExists);
        }

        [Theory]
        [InlineData("admin")]
        [InlineData("supervisor")]
        [InlineData("zhangsan")]
        public void When_username_is_exists_returns_true(string username)
        {
            // Arrange


            // Act
            var isExists = _userService.IsUsernameExists(username);

            // Assert
            Assert.True(isExists);
        }

        [Theory]
        [InlineData("admin ")]
        [InlineData(" admin")]
        [InlineData("lisi")]
        public void When_username_is_no_exists_returns_false(string username)
        {
            // Arrange


            // Act
            var isExist = _userService.IsUsernameExists(username);

            // Assert
            Assert.False(isExist);
        }

    }
}
