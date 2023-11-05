using Fiap.Noticias.Domain.Model.Entities.Base;
using Fiap.Noticias.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Model.Entities
{
    public class Noticia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public string Autor { get; set; }

        public Noticia(string titulo, string descricao, DateTime dataPublicacao, string autor)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Autor = autor;
            ValidaClasse();
        }

        public Noticia() { }

        public void ValidaClasse()
        {
            ValidacaoClasse.GaranteSeStringNaoENulaNemVazia(Titulo, "O título não pode ser nulo");
            ValidacaoClasse.GaranteSeStringNaoENulaNemVazia(Descricao, "A descrição não pode ser nula");
            ValidacaoClasse.GaranteSeStringNaoENulaNemVazia(Autor, "O autor não pode ser nulo");
            ValidacaoClasse.GaranteTamanhoString(Titulo, 255, 5, "O título precisa ter entre 5 e 255 caracteres");
            ValidacaoClasse.GaranteTamanhoString(Descricao, 5000, 10, "A descrição precisa ter entre 10 e 5000 caracteres");
            ValidacaoClasse.GaranteTamanhoString(Autor, 255, 5, "O autor precisa ter entre 5 e 255 caracteres");
            ValidacaoClasse.GaranteDataAnteriorOuIgualAAtual(DataPublicacao, "A Data de Publicação não deve ser posterior a de hoje");
            ValidacaoClasse.GaranteDataAposOuIgualAAtual(DataPublicacao, "A Data de Publicação não deve ser anterior a de hoje");
        }
    }
}
