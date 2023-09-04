using Fiap.Noticias.Domain.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Model.Entities
{
    public class Noticia : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public string Autor { get; set; }
    }
}
