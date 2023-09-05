using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.ViewModel.Response
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
