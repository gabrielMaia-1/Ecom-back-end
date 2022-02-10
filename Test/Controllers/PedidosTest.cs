using Api.Commons.Mappings;
using Api.Controllers;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Domain.Common.Entities;
using Domain.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Utils;
using Xunit;

namespace Test.Controllers
{
    public class PedidosTest
    {
        private PedidosController Controller { get; set; }
        private IMapper Mapper { get; set; }
        public PedidosTest()
        {
            Mapper = ApiMapperBuilder.CreateDefaultMap();
            Controller = new PedidosController();
        }

        [Fact]
        public async Task GetAll_ReturnMappedVPedidos()
        {
            // Arrange
            var page = 1;
            var pageSize = 10;
            var repoMock = new Mock<IPedidoRepository>();

            repoMock.Setup(x => x.GetPedidosPaginadoAsync(pageSize, page))
                .ReturnsAsync((GetVPedidosData(), 40));

            // Act
            var response = await Controller.GetAll(repoMock.Object, Mapper, pageSize, page);

            // Assert Ok
            Assert.IsAssignableFrom<OkObjectResult>(response.Result);
        }

        private IEnumerable<FatoPedidosModel> GetVPedidosData()
        {
            foreach(var vpm in Enumerable.Range(1,40))
            {
                yield return new FatoPedidosModel
                {
                    PedidoId = vpm,
                    DataInclusao = DateTime.Now,
                    DataEntrega = DateTime.Now,
                    Endereco = GetVEnderecoData(),
                    Produtos = GetListProdutoData(),
                };
            }

        }
        private EnderecoModel GetVEnderecoData()
        {
            return new EnderecoModel
            {
                EnderecoId = 1,
                EstadoId = 1,
                Estado = "Mato Grosso do Sul",
                Endereco = "Rua do Mock",
                Cidade = "Testelandia",
                CidadeId = 3,
                Cep = "09578947",
                Uf = "MS"
            };
        }

        private List<Produto> GetListProdutoData()
        {
            return new List<Produto>
                    {
                        new Produto
                        {
                            Id = 1,
                            Nome = "teste",
                            Descricao = "o produto feito para testes",
                            PedidoProduto = null,
                            Valor = 12.3m
                        }
                    };
        }
    }
}
