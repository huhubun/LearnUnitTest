namespace LearnUnitTest.Services.Users
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserService _userService;

        public UserRegistrationService(IUserService userService)
        {
            _userService = userService;
        }

        public UserLoginResults ValidateUser(string username, string password)
        {
            var user = _userService.GetUserByUsername(username);

            if (user == null)
            {
                return UserLoginResults.NotExist;
            }

            if (user.Password != password)
            {
                return UserLoginResults.WrongPassword;
            }

            return UserLoginResults.Successful;
        }
    }
}
