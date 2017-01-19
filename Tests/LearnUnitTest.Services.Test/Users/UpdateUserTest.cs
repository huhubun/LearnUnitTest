using LearnUnitTest.Core.Data;
using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnUnitTest.Services.Test.Users
{
    public class UpdateUserTest
    {
        private readonly UserService _userService;
        private readonly Mock<IRepository<User>> _mockUserRepository;

        public UpdateUserTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization()); ;

            _mockUserRepository = fixture.Freeze<Mock<IRepository<User>>>();
            _mockUserRepository.Setup(r => r.Update(It.IsNotNull<User>()));

            _userService = fixture.Create<UserService>();
        }

        [Fact]
        public void When_user_is_null_throws_exception()
        {
            // Arrange
            User user = null;

            // Act


            // Assert
            Assert.Throws<ArgumentNullException>(nameof(user), () => _userService.UpdateUser(user));
        }

        [Fact]
        public void User_succefully_update()
        {
            // Arrange
            var user = new User { Id = 1, Username = "admin" };

            // Act
            _userService.UpdateUser(user);

            // Assert
            _mockUserRepository.Verify(repository => repository.Update(user), Times.Once());
        }
    }
}
