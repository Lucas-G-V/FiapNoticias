using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.ViewModel.Response
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public UsuarioViewModel User { get; set; }
    }
}
