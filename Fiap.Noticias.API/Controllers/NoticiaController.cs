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

        [HttpGet("ObterPorId/{id:guid}")]
        public async Task<ActionResult<Noticia>> ObterPorId(Guid id)
        {
            var noticia = await _noticiaService.GetById(id);

            if (noticia == null) return NotFound();

            return Ok(noticia);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Noticia>>> ObterTodos()
        {
            var noticias = await _noticiaService.GetAll();

            if (noticias == null) return NotFound();

            return Ok(noticias);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Noticia noticia)
        {
            var noticias = await _noticiaService.Add(noticia);

            return CreatedAtAction(nameof(ObterPorId), new {Id = noticia.Id}, noticia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(Guid id, [FromBody] Noticia noticia)
        {
            var noticias = await _noticiaService.Update(noticia, id);
            if(noticias == 0) { return NotFound(); }    
            return Ok(noticias);
        }
    }
}
