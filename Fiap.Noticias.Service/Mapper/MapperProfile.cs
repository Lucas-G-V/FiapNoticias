﻿using AutoMapper;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NoticiaViewModel, Noticia>()
                .ConstructUsing(x => new Noticia(x.Titulo, x.Descricao, x.DataPublicacao, x.Autor));
            CreateMap<Noticia, NoticiaViewModel>();
        }
    }
}
