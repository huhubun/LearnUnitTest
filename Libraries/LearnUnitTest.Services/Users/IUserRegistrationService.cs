namespace LearnUnitTest.Services.Users
{
    public interface IUserRegistrationService
    {
        UserLoginResults ValidateUser(string username, string password);
    }
}
