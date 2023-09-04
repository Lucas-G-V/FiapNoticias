using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Service.Services
{
    public class NoticiaService : INoticiaService
    {
        private readonly INoticiaRepository _noticiaRepository;
        public NoticiaService(INoticiaRepository noticiaRepository) 
        {
            _noticiaRepository = noticiaRepository;
        }
        public async Task<int> Add(Noticia noticia)
        {
           return await _noticiaRepository.Add(noticia);
        }

        public async Task<List<Noticia>> GetAll()
        {
            return await _noticiaRepository.GetAll();
        }

        public async Task<Noticia> GetById(Guid id)
        {
            return await _noticiaRepository.GetById(id);
        }

        public async Task<int> Update(Noticia noticia, Guid id)
        {
            if(await _noticiaRepository.GetById(id) != null)
            {
                return await _noticiaRepository.Update(noticia);
            }
            return 0;
        }
    }
}
