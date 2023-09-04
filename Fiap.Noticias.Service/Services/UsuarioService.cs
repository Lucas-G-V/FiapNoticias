using Fiap.Noticias.CrossCutting;
using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Fiap.Noticias.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISecurityService _securityService;

        public UsuarioService(IUsuarioRepository usuarioRepository, ISecurityService securityService)
        {
            _usuarioRepository = usuarioRepository;
            _securityService = securityService;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var usuario = await _usuarioRepository.GetByEmail(loginRequest.Email);
            if(usuario != null)
            {
                if (_securityService.Criptografar(loginRequest.Senha) == usuario.Senha)
                {
                    return _securityService.CreateToken(usuario.Nome);
                }
            }
            return null;
        }
    }
}
