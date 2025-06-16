using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Smart_Tire_app_Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Smart_Tire_app_Server.Security
{
    public class TokenProvider2(IConfiguration configuration)
    {
        public string CreateToken(User user)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Secret"))
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken
            (
                issuer: configuration.GetValue<string>("Jwt:Issuer"),
                audience: configuration.GetValue<string>("Jwt:Audience"),
                claims: Claims,
                expires: DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExpirationInMinutes"))
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
