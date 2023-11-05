using Bogus;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.TesteUnidade.Entities
{
    public class NoticiaTest
    {
        private readonly Faker _faker;
        public NoticiaTest()
        {
            _faker = new Faker();
        }

        [Fact(DisplayName = "Validando se o titulo esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoTituloVazio()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(null, _faker.Random.String2(15), DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("O título não pode ser nulo", result.Message);
        }

        [Fact(DisplayName = "Validando se o titulo está com menos caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoTituloMenosCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(1), _faker.Random.String2(15), DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("O título precisa ter entre 5 e 255 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se o titulo está com mais caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoTituloMaisCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(256), _faker.Random.String2(15), DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("O título precisa ter entre 5 e 255 caracteres", result.Message);
        }
    }
}
