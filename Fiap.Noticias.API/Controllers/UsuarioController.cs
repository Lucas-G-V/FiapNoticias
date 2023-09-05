using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;
using Fiap.Noticias.Domain.ViewModel.Response;
using Fiap.Noticias.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [ProducesResponseType(typeof(LoginResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            var usuarioResponse = await _usuarioService.Login(loginRequest);

            if (usuarioResponse == null) return BadRequest("Login/Senha inválido");

            return Ok(usuarioResponse);
        }
    }
}
