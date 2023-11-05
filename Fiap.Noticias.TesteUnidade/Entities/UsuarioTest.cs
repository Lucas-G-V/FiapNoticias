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
    public class UsuarioTest
    {
        private readonly Faker _faker;
        public UsuarioTest()
        {
            _faker = new Faker();
        }

        [Fact(DisplayName = "Validando um usuário valido")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoUsuarioValido()
        {
            var email = _faker.Internet.Email();
            var usuario = new Usuario(_faker.Name.FullName(), email, "Teste123");
            Assert.Equal(email, usuario.Email);
        }


        [Fact(DisplayName = "Validando se o nome esta vazio")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExcecaoNomeVazio()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(null, _faker.Internet.Email(), "Teste123"));
            Assert.Equal("Nome não pode ser nulo", result.Message);
        }

        [Fact(DisplayName = "Validando se o nome está com menos caracteres")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExcecaoNomeMenosCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Random.String2(1), _faker.Internet.Email(), "Teste123"));
            Assert.Equal("Nome tem que ter entre 2 e 255 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se o nome está com mais caracteres")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExcecaoNomeMaisCaracteres()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Random.String2(256), _faker.Internet.Email(), "Teste123"));
            Assert.Equal("Nome tem que ter entre 2 e 255 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se a senha so de letras e reprovada")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExececaoSenhaSoDeLetras()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Name.FullName(), _faker.Internet.Email(), "testeeeee"));
            Assert.Equal("Senha não tem letras e números e deve ter 8 a 15 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se a senha so de numeros e reprovada")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExececaoSenhaSoDeNumeros()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Name.FullName(), _faker.Internet.Email(), "12345678"));
            Assert.Equal("Senha não tem letras e números e deve ter 8 a 15 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se a senha so de letras e reprovada")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExececaoTamanhoSenhaMenorQue8()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Name.FullName(), _faker.Internet.Email(), "teste12"));
            Assert.Equal("Senha não tem letras e números e deve ter 8 a 15 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando se a senha so de letras e reprovada")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoSeGeraExececaoSenhaMaiorQue15()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Name.FullName(), _faker.Internet.Email(), "huadsihdfiuashnfiuasgfabsiufhauisfuiafhuahfu"));
            Assert.Equal("Senha não tem letras e números e deve ter 8 a 15 caracteres", result.Message);
        }

        [Fact(DisplayName = "Validando email errado")]
        [Trait("Categoria", "Validando Usuário")]
        public void ValidandoEmailErrado()
        {
            var result = Assert.Throws<DomainException>(() => new Usuario(_faker.Name.FullName(), "teste123", "Teste123"));
            Assert.Equal("Não é um email válido", result.Message);
        }
    }
}
