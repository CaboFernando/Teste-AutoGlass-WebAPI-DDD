using Dominio.Interfaces;
using Dominio.Servicos;
using Entidades.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dominio.Tests.Servicos
{
    public class ServicoProdutoTests
    {
        private ServicoProduto servicoProduto;

        public ServicoProdutoTests()
        {
            servicoProduto = new ServicoProduto(new Mock<IProduto>().Object);
        }

        #region testes no AdicionaProduto

        [Fact]
        public void AdicionaProduto_EnviaCodigoInvalido()
        {
            var produto = new Produto { CodigoProduto = 2 };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AdicionaProduto(produto));

            Assert.Equal("Não é necessário enviar o CodigoProduto para adicionar um novo produto", exception.Result.Message);
        }

        [Fact]
        public void AdicionaProduto_EnviaDescricaoProdutoInvalido()
        {
            var produto = new Produto { DescricaoProduto = null };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AdicionaProduto(produto));

            Assert.Equal("A DescricaoProduto é obrigatória", exception.Result.Message);
        }

        [Fact]
        public void AdicionaProduto_EnviaDatasInvalidas()
        {
            var data = new DateTime(2022, 05, 17);

            var produto = new Produto { DescricaoProduto = "descrição",  DataFrabricacao = data, DataValidade = data };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AdicionaProduto(produto));

            Assert.Equal("A DataFrabricacao não pode ser menor ou igual a DataValidade", exception.Result.Message);
        }

        #endregion

        #region testes no AtualizarProduto

        [Fact]
        public void AtualizarProduto_EnviaCodigoInvalido()
        {
            var produto = new Produto { CodigoProduto = 0 };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AtualizaProduto(produto));

            Assert.Equal("O CodigoProduto é obrigatório para atualizar um produto", exception.Result.Message);
        }

        [Fact]
        public void AtualizarProduto_EnviaDescricaoProdutoInvalido()
        {
            var produto = new Produto { CodigoProduto = 1, DescricaoProduto = null };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AtualizaProduto(produto));

            Assert.Equal("A DescricaoProduto é obrigatória", exception.Result.Message);
        }

        [Fact]
        public void AtualizarProduto_EnviaDatasInvalidas()
        {
            var data = new DateTime(2022, 05, 17);

            var produto = new Produto { CodigoProduto = 1,  DescricaoProduto = "descrição", DataFrabricacao = data, DataValidade = data };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.AtualizaProduto(produto));

            Assert.Equal("A DataFrabricacao não pode ser menor ou igual a DataValidade", exception.Result.Message);
        }

        #endregion

        #region testes no BuscaPorCodigo

        [Fact]
        public void BuscaPorCodigo_EnviaCodigoInvalido()
        {
            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.BuscaPorCodigo(0));

            Assert.Equal("O CodigoProduto informado é inválido", exception.Result.Message);
        }

        #endregion

        #region testes no RemoveProduto

        [Fact]
        public void RemoveProduto_EnviaCodigoInvalido()
        {
            var produto = new Produto { CodigoProduto = 0 };

            var exception = Assert.ThrowsAsync<Exception>(() => servicoProduto.RemoveProduto(produto));

            Assert.Equal("Não existe nenhum produto ativo com o CodigoProduto informado", exception.Result.Message);
        }

        #endregion
    }
}
