using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.ViewModel.Request;
using Fiap.Noticias.Domain.ViewModel.Response;

namespace Fiap.Noticias.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<LoginResponseViewModel> Login(LoginRequest loginRequest);
    }
}
