using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Noticias.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<ActionResult<int>> Post([FromBody] NoticiaViewModel noticia)
        {
            var noticias = await _noticiaService.Add(noticia);
            noticia.Id = noticias;
            return CreatedAtAction(nameof(ObterPorId), new {Id = noticias}, noticia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(Guid id, [FromBody] Noticia noticia)
        {
            var noticias = await _noticiaService.Update(noticia, id);
            if(noticias == 0) { return NotFound(); }    
            return Ok(noticia);
        }
    }
}
