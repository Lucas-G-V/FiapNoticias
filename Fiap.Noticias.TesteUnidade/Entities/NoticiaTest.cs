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

        [Fact(DisplayName = "Validando se o Autor esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoAutorVazio()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), _faker.Random.String2(15), DateTime.Now, null));
            Assert.Equal("O autor não pode ser nulo", result.Message);
        }

        [Fact(DisplayName = "Validando se o Autor está com menos caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoAutorMenosCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), _faker.Random.String2(15), DateTime.Now, _faker.Random.String2(1)));
            Assert.Equal("O autor precisa ter entre 5 e 255 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se o autor está com mais caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoAutorMaisCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), _faker.Random.String2(15), DateTime.Now, _faker.Random.String2(256)));
            Assert.Equal("O autor precisa ter entre 5 e 255 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se a descricao esta vazio")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoDescricaoVazio()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), null, DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("A descrição não pode ser nula", result.Message);
        }

        [Fact(DisplayName = "Validando se o titulo está com menos caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoDescricaoMenosCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), _faker.Random.String2(1), DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("A descrição precisa ter entre 10 e 5000 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se o titulo está com mais caracteres")]
        [Trait("Categoria", "Validando Noticias")]
        public void ValidandoSeGeraExcecaoDescricaoMaisCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Noticia(_faker.Random.String2(15), _faker.Random.String2(5001), DateTime.Now, _faker.Random.String2(15)));
            Assert.Equal("A descrição precisa ter entre 10 e 5000 caracteres", result.Message);
        }
    }
}
