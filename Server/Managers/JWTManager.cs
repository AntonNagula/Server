using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server.Managers
{
    public class JWTManager
    {
        public JWTManager()
        {

        }
        public string GetTokenFromHeader(string bearer)
        {
            string token = bearer.Remove(0,7);
            return token;
        }
        public string GetUserNameFromJWT(string jwt)
        {
            string secret = "superSecretKey@345";
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(jwt, validations, out var tokenSecure);
            return claims.Identity.Name;
        }
        public string GetPasswordFromJWT(string jwt)
        {
            string secret = "superSecretKey@345";
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(jwt, validations, out var tokenSecure);
            return claims.FindFirstValue("Password");
        }
        public string GenerateToken(string role, string username, string password)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:54717",
                audience: "http://localhost:54717",
                claims: new List<Claim> { new Claim(ClaimTypes.Role, role), new Claim(ClaimTypes.Name, username), new Claim("Password", password) },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
