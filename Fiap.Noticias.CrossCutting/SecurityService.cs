using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.CrossCutting
{
    public interface ISecurityService
    {
        string CreateToken(string nomeUsuario);
    }
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        public SecurityService(IConfiguration configuration)
        {
            _configuration  = configuration;
        }
        public string CreateToken(string nomeUsuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, nomeUsuario),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
