using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Fiap.Noticias.API.Controllers;
using Fiap.Noticias.Domain.ViewModel;
using Newtonsoft.Json;
using System.Text;
using Fiap.Noticia.TesteIntegracao.Config;

namespace Fiap.Noticias.TesteIntegracao.Controllers
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class NoticiaIntegrationTest : IClassFixture<NoticiaAppFactory<Program>>
    {
        private readonly Faker _faker;
        private readonly TesteIntegracaoFixture _fixture;
        public NoticiaIntegrationTest(TesteIntegracaoFixture fixture)
        {
            _faker = new Faker();
            _fixture = fixture;
        }

        [Fact(DisplayName = "Validando GetAll")]
        [Trait("Categoria", "Validando Controller Noticias")]
        public async Task GetAll_ReturnsOkResult()
        {
            await _fixture.RealizarCadastroUsuario();
            await _fixture.RealizarLoginApi();
            _fixture.Client.AtribuirToken(_fixture.AccessToken);

            var client = _fixture.Client;

            var response = await client.GetAsync("/Noticia/GetAll");

            response.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Validando Post")]
        [Trait("Categoria", "Validando Controller Noticias")]
        public async Task PostNoticiaOkResult()
        {
            await _fixture.RealizarCadastroUsuario();
            await _fixture.RealizarLoginApi();
            _fixture.Client.AtribuirToken(_fixture.AccessToken);

            var client = _fixture.Client;
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
