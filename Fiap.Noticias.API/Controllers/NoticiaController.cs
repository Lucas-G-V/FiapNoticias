using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Noticias.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _noticiaService;
        public NoticiaController(INoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Noticia>> ObterPorId(Guid id)
        {
            var receita = await _noticiaService.GetById(id);

            if (receita == null) return NotFound();

            return Ok(receita);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Noticia>>> ObterTodos()
        {
            var receitas = await _noticiaService.GetAll();

            if (receitas == null) return NotFound();

            return Ok(receitas);
        }
    }
}
