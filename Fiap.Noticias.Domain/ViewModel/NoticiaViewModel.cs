using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.ViewModel
{
    public class NoticiaViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        [Required]
        public string Autor { get; set; }
    }
}
