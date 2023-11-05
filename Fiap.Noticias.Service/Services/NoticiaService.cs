using AutoMapper;
using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel;
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
        private readonly IMapper _mapper;
        public NoticiaService(INoticiaRepository noticiaRepository, IMapper mapper) 
        {
            _noticiaRepository = noticiaRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Add(NoticiaViewModel noticia)
        {
           var noticiaNova = _mapper.Map<Noticia>(noticia);
           await _noticiaRepository.Add(noticiaNova);
            return noticiaNova.Id;
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
