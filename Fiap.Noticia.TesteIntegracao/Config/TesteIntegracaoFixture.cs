using Azure.Core;
using Fiap.Noticias.Domain.ViewModel.Request;
using Fiap.Noticias.Domain.ViewModel.Response;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticia.TesteIntegracao.Config
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<TesteIntegracaoFixture> { }
    public class TesteIntegracaoFixture : IDisposable
    {
        private readonly NoticiaAppFactory<Program> Factory;
        public HttpClient Client;
        public string AccessToken;
        private string Email = "teste@teste.com";
        private string Senha = "Teste123";
        private bool JaFezLogin = false;
        private bool JaFezCadastro = false;
        public TesteIntegracaoFixture()
        {
            Factory = new NoticiaAppFactory<Program>();
            Client = Factory.CreateClient();
        }

        public async Task RealizarCadastroUsuario()
        {
            if (!JaFezCadastro)
            {
                var userData = new UsuarioCreateRequest
                {
                    Email = Email,
                    Senha = Senha,
                    Nome = "Lucas Teste"
                };
                Client = Factory.CreateClient();

                var response = await Client.PostAsJsonAsync("Usuario/Criar", userData);
                response.EnsureSuccessStatusCode();
                JaFezCadastro = true;
            }
        }

        public async Task RealizarLoginApi()
        {
            if (!JaFezLogin)
            {
                var userData = new LoginRequest
                {
                    Email = Email,
                    Senha = Senha
                };
                Client = Factory.CreateClient();

                var response = await Client.PostAsJsonAsync("Usuario/Login", userData);
                response.EnsureSuccessStatusCode();
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();
                AccessToken = loginResponse.AccessToken;
                JaFezLogin = true;
            }
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
