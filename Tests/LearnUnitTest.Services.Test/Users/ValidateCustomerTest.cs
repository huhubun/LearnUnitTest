using LearnUnitTest.Core.Domain.Users;
using LearnUnitTest.Services.Users;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;

namespace LearnUnitTest.Services.Test.Users
{
    public class ValidateCustomerTest
    {
        private readonly UserRegistrationService _userRegistrationService;

        public ValidateCustomerTest()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var mockUserService = fixture.Freeze<Mock<IUserService>>();
            mockUserService.Setup(u => u.GetUserByUsername(It.Is<string>(name => name == "admin")))
                .Returns(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "Pa$$w0rd"
                });
            mockUserService.Setup(u => u.GetUserByUsername(It.Is<string>(name => name == "zhangsan")))
                .Returns(() => null);

            _userRegistrationService = fixture.Create<UserRegistrationService>();
        }

        [Fact]
        public void When_username_and_password_are_correct_returns_success()
        {
            // Arrange
            var username = "admin";
            var password = "Pa$$w0rd";

            // Act
            var userLoginResult = _userRegistrationService.ValidateUser(username, password);

            // Assert
            Assert.Equal(UserLoginResults.Successful, userLoginResult);
        }

        [Fact]
        public void When_username_is_not_exist_returns_not_exist()
        {
            // Arrange
            var username = "zhangsan";
            var password = "1234";

            // Act
            var userLoginResult = _userRegistrationService.ValidateUser(username, password);

            // Assert
            Assert.Equal(UserLoginResults.NotExist, userLoginResult);
        }

        [Fact]
        public void When_password_is_failed_returns_wrong_password()
        {
            // Arrange
            var username = "admin";
            var password = "1234";

            // Act
            var userLoginResult = _userRegistrationService.ValidateUser(username, password);

            // Assert
            Assert.Equal(UserLoginResults.WrongPassword, userLoginResult);
        }
    }
}
