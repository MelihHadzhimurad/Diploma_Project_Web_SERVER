﻿using Microsoft.AspNetCore.Mvc;
using Smart_Tire_app_Server.Additionals;
using Smart_Tire_app_Server.CustomExceptions;
using Smart_Tire_app_Server.Services;

namespace Smart_Tire_app_Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost(Name = "login")]
        public ActionResult<string> Login([FromBody] LoginRequest request)
        {
            try
            {
                string token = _authenticationService.CheckCredentials(request.UserName, request.Password);
                return token;
            }
            catch (UserNotFoundException)
            { 
                return NotFound("Невалидни данни!"); 
            }
        }
    }
}
