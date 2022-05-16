using Entidades.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("TB_PRODUTO")]
    public class Produto : Notifica
    {
        [Key]
        [Column("ID_COD_PRODUTO")]
        public int CodigoProduto { get; set; }

        [Required]
        [Column("DESCRICAO_PRODUTO")]
        public string DescricaoProduto { get; set; }

        [Column("SITUACAO_PRODUTO")]
        public bool SituacaoProduto { get; set; }

        [Column("DATA_FABRICACAO")]
        public DateTime DataFrabricacao { get; set; }

        [Column("DATA_VALIDADE")]
        public DateTime DataValidade { get; set; }

        [Column("COD_FORNECEDOR")]
        public int CodigoFornecedor { get; set; }

        [Column("DESCRICAO_FORNECEDOR")]
        public string DescricaoFornecedor { get; set; }

        [Column("CNPJ_FORNECEDOR")]
        public string CnpjFornecedor { get; set; }

    }
}
