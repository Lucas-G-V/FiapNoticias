using Fiap.Noticias.CrossCutting.IoC;

namespace Fiap.Noticias.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            DependencyInjection.RegisterServices(services);
        }
    }
}
