using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.DataBaseContext;
using Smart_Tire_app_Server.Models;
using Smart_Tire_app_Server.Security;

namespace Smart_Tire_app_Server.Services
{
    public class AuthenticationService
    {
        private readonly ApplicationDbContext _context;

        private readonly JwtTokenProvider _jwtTokenProvider;

        public AuthenticationService(ApplicationDbContext context, JwtTokenProvider jwtTokenProvider)
        {
            _context = context;
            _jwtTokenProvider = jwtTokenProvider;
        }

        public string CheckCredentials(string username, string pasword) 
        {
            _context.Database.EnsureCreated();

            foreach (User user in _context.Users)
            {
                if (user.UserName == username && user.Password == pasword)
                {
                    return _jwtTokenProvider.create(user);
                }
            }



            throw new UserNotFoundException();
        }
    }
}
