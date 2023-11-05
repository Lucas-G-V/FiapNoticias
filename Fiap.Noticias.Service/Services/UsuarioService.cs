using AutoMapper;
using Fiap.Noticias.CrossCutting;
using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;
using Fiap.Noticias.Domain.ViewModel.Response;
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
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, ISecurityService securityService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _securityService = securityService;
            _mapper = mapper;
        }

        public async Task<int> CriarUsuario(UsuarioCreateRequest usuario)
        {
            var usuarioCreate = _mapper.Map<Usuario>(usuario);  
            usuarioCreate.Senha = _securityService.Criptografar(usuarioCreate.Senha);
            return await _usuarioRepository.Criar(usuarioCreate);
        }

        public async Task<LoginResponseViewModel> Login(LoginRequest loginRequest)
        {
            var usuario = await _usuarioRepository.GetByEmail(loginRequest.Email);
            if(usuario != null)
            {
                if (_securityService.Criptografar(loginRequest.Senha) == usuario.Senha)
                {
                    var token = _securityService.CreateToken(usuario.Nome);
                    return AjustaResponse(token, usuario);
                }
            }
            return null;
        }

        private LoginResponseViewModel AjustaResponse(string token, Usuario usuario)
        {
            var usuarioResponse = new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
            return new LoginResponseViewModel { AccessToken = token, User = usuarioResponse };
        }
    }
}
