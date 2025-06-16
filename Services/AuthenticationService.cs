using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.DataBaseContext;
using Smart_Tire_app_Server.Models;
using Smart_Tire_app_Server.Security;

namespace Smart_Tire_app_Server.Services
{
    public class AuthenticationService
    {
        private readonly ApplicationDbContext _context;

        private readonly TokenProvider2 _jwtTokenProvider;

        private readonly PasswordHasher _passwordHasher;

        public AuthenticationService(ApplicationDbContext context, TokenProvider2 jwtTokenProvider, PasswordHasher passwordHasher)
        {
            _context = context;
            _jwtTokenProvider = jwtTokenProvider;
            _passwordHasher = passwordHasher;
        }

        public string CheckCredentials(string username, string pasword) 
        {
            _context.Database.EnsureCreated();

            foreach (User user in _context.Users)
            {
                if (user.UserName == username && user.Password.Split("-")[0] == _passwordHasher.Hash(pasword).Split("-")[0])
                {
                    return _jwtTokenProvider.CreateToken(user);
                }
            }

            throw new UserNotFoundException();
        }
    }
}
