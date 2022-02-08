using Domain.Common.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Common.Services
{
    public class TokenService
    {
        private static TokenService Instance { get; set; }
        private string Secret { get; set; }
        private TokenService()
        {
        }

        private static TokenService GetInstance()
        {
            if (Instance is null) Instance = new TokenService();
            return Instance;
        }
        internal static void SetSecret(string secret)
        {
            GetInstance().Secret = secret;
        }
        public static string GenerateToken(Usuario user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GetInstance().Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                })
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }
    }
}