using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.CrossCutting
{
    public interface ISecurityService
    {
        string CreateToken(string nomeUsuario);
        public string Criptografar(string texto);
    }
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        byte[] chave = { 100, 33, 22, 1, 3, 9, 5, 233, 6, 145, 131, 52, 220, 98, 132, 12 };
        byte[] iv = { 79, 155, 5, 131, 213, 98, 31, 44, 9, 39, 241, 249, 49, 199, 15, 8 };
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

        private static byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
        {
            byte[] cipheredtext;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(simpletext);
                        }

                        cipheredtext = memoryStream.ToArray();
                    }
                }
            }
            return cipheredtext;
        }

        public string Criptografar(string texto)
        {
            return Convert.ToBase64String(Encrypt(texto, chave, iv));
        }
    }
}
