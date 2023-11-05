using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Fiap.Noticias.API.Controllers;
using Fiap.Noticias.Domain.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace Fiap.Noticias.TesteIntegracao.Controllers
{
    public class NoticiaIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Faker _faker;
        public NoticiaIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _faker = new Faker();
            _factory = factory;
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Noticia/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PostNoticiaOkResult()
        {
            var client = _factory.CreateClient();
            var noticiaViewModel = new NoticiaViewModel
            {
                Titulo = _faker.Random.String2(10),
                Descricao = _faker.Random.String2(10),
                Autor = _faker.Random.String2(10)
            };

            var content = new StringContent(JsonConvert.SerializeObject(noticiaViewModel), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/Noticia", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
