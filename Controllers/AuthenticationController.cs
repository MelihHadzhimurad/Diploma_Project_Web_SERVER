using Microsoft.AspNetCore.Mvc;
using Smart_Tire_app_Server.Additionals;
using Smart_Tire_app_Server.Security;
using Smart_Tire_app_Server.Services;

namespace Smart_Tire_app_Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        private readonly PasswordHasher _passwordHasher;

        public AuthenticationController(AuthenticationService authenticationService, PasswordHasher passwordHasher)
        {
            _authenticationService = authenticationService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost(Name = "login")]
        public ActionResult<string> Login([FromBody] LoginRequest request)
        {
            try
            {
                string token = _authenticationService.CheckCredentials(request.UserName, request.Password);
                return token;
            }
            catch (Exception ex)
            { 
                return _passwordHasher.Hash(request.Password); 
            }
        }
    }
}
