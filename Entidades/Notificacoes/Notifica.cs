using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Notificacoes
{
    public class Notifica
    {
        public Notifica()
        {
            Notificacoes = new List<Notifica>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public List<Notifica> Notificacoes;

        public bool ValidarPropriedadesString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if(valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
        public bool ValidarDataMaiorQueOutra(DateTime primeiroValor, DateTime segundoValor, string nomePrimeiraPropriedade, string nomeSegundaPropriedade)
        {
            if (primeiroValor >= segundoValor || (string.IsNullOrWhiteSpace(nomePrimeiraPropriedade) && string.IsNullOrWhiteSpace(nomeSegundaPropriedade)))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem = primeiroValor + " não pode ser menor ou igual á " + segundoValor,
                    NomePropriedade = nomePrimeiraPropriedade + ", " + nomeSegundaPropriedade
                });
                return false;
            }
            return true;
        }

    }
}
