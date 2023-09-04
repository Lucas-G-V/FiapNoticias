using Fiap.Noticias.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Interfaces.Services
{
    public interface INoticiaService
    {
        Task<List<Noticia>> GetAll();
        Task<Noticia> GetById(Guid id);
        Task<int> Add(Noticia noticia);
        Task<int> Update(Noticia noticia, Guid id);
    }
}
