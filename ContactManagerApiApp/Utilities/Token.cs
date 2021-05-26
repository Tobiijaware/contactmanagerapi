using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace ContactManagerApiApp.Utilities
{
    public static class Token
    {
        public static string GenerateToken(string username, string Id, string email,IQueryable<IdentityRole> roles, IConfiguration config)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.NameIdentifier,Id)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            //create securty token descriptor
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:JWTSigningKey"]));
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)

            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenCreated = tokenHandler.CreateToken(securityTokenDescriptor);

            var  token = tokenHandler.WriteToken(tokenCreated);
            return token;
            
        }


        public static JwtSecurityToken Verify(string token, IConfiguration config)
        {
            var tokenHandler =new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config.GetSection("JWT:JWTSigningKey").Value);
            tokenHandler.ValidateToken(token, new TokenValidationParameters() {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken); ;
            return (JwtSecurityToken)validatedToken;
        }
    }
}
