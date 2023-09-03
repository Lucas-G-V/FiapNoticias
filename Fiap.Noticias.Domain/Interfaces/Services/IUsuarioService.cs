using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;

namespace Fiap.Noticias.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<string> Login(LoginRequest loginRequest);
    }
}
