using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;
using Fiap.Noticias.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Noticias.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var accessToken = await _usuarioService.Login(loginRequest);

            if (accessToken == null) return BadRequest("Login/Senha inválido");

            return Ok(accessToken);
        }
    }
}
