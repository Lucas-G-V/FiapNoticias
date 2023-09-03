using Fiap.Noticias.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByEmail(string email);
    }
}
