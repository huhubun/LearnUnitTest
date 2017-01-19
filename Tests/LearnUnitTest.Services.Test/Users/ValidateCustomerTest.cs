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
        [Fact]
        public void Username_and_password_are_correct_returns_success()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var mockUserService = fixture.Freeze<Mock<IUserService>>();
            mockUserService.Setup(u => u.GetUserByUsername(It.Is<string>(name => name == "admin")))
                .Returns(new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "Pa$$w0rd"
                });

            var userRegistrationService = fixture.Create<UserRegistrationService>();

            var username = "admin";
            var password = "Pa$$w0rd";

            // Act
            var userLoginResult = userRegistrationService.ValidateUser(username, password);

            // Assert
            Assert.Equal(UserLoginResults.Successful, userLoginResult);
        }


    }
}
