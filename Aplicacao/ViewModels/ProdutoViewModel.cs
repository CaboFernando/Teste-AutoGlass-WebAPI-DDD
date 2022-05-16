using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.ViewModels
{
    public class ProdutoViewModel
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime DataFrabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
