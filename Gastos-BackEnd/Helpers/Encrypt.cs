using Gastos_BackEnd.Interfaces.IRepository;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gastos_BackEnd.Helpers
{
    public class Encrypt
    {
      
        public static string HashPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        public static bool ComparePassword(string password, string hashpassword)
        {
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, hashpassword);
            return isValidPassword;
        }
        public static  string GenerateToken(Persona Persona, string secretToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretToken);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Persona.Personald.ToString()),
                        new Claim(ClaimTypes.Email, Persona.Email),
                        new Claim(ClaimTypes.Name, Persona.Nombre),
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
