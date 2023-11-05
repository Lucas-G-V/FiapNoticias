using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Utils
{
    public class ValidacaoClasse
    {

        public static void GaranteSeStringNaoENulaNemVazia(string stringValue, string mensagemDeErro)
        {
            if(string.IsNullOrEmpty(stringValue)) 
            {
                throw new DomainException(mensagemDeErro);
            }
        }
        public static void VerificaSeENulo(object value, string mensagemDeErro)
        {
            if (value == null)
            {
                throw new DomainException(mensagemDeErro);
            }
        }
        public static void GaranteTamanhoString(string stringValue, int maximo, int minimo, string mensagemDeErro)
        {
            int length = stringValue.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagemDeErro);
            }
        }

        public static void GaranteDataAposOuIgualAAtual(DateTime dataComparada, string mensagemDeErro)
        {
            if(dataComparada.Date < DateTime.Now.Date)
            {
                throw new DomainException(mensagemDeErro);
            }
        }

        public static void GaranteDataAnteriorOuIgualAAtual(DateTime dataComparada, string mensagemDeErro)
        {
            if (dataComparada.Date > DateTime.Now.Date)
            {
                throw new DomainException(mensagemDeErro);
            }
        }

    }
}
