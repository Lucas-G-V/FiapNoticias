using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Interfaces.Services;
using Fiap.Noticias.Infra.Data.Repositories;
using Fiap.Noticias.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<INoticiaService, NoticiaService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<INoticiaRepository, NoticiaRepository>();

            services.AddScoped<ISecurityService, SecurityService>();
        }
    }
}
