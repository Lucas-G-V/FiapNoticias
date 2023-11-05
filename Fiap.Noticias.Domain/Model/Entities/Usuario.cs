using Fiap.Noticias.Domain.Model.Entities.Base;
using Fiap.Noticias.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Model.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario(string nome, string email, string senha) 
        {
            Nome = nome;
            DefineSenhaSeAtenderRequisitos(senha);
            VerificaEDefineEmail(email);
            ValidaUsuario();
        }
        public Usuario() { }

        private void DefineSenhaSeAtenderRequisitos(string senha)
        {
            Regex regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)[A-Za-z\d]{8,15}$");
            if (!regex.IsMatch(senha)) throw new DomainException("Senha não tem letras e números e deve ter 8 a 15 caracteres");
            Senha = senha;
        }

        private void VerificaEDefineEmail(string email)
        {
            Regex regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            if (!regex.IsMatch(email)) throw new DomainException("Não é um email válido");
            Email = email;
        }

        public void ValidaUsuario()
        {
            ValidacaoClasse.GaranteSeStringNaoENulaNemVazia(Nome, "Nome não pode ser nulo");
            ValidacaoClasse.GaranteTamanhoString(Nome, 255, 2, "Nome tem que ter entre 2 e 255 caracteres");
        }
    }
}
