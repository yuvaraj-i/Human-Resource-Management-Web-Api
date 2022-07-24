using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HumanResourceManagement.AuthenticationUtils
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _config;

        public JwtTokenManager(IConfiguration config)
        {
            _config = config;
        }

        public Token GenerateUserToken(string id, string role)
        {
            var securityKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id),
                    new Claim(ClaimTypes.Role, role.ToLower())
                }),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(securityKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token()
            {
                AccessToken = tokenHandler.WriteToken(token)
            };
        }
    }
}
