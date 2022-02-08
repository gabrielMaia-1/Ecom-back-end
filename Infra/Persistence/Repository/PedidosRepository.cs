using System.Collections.Generic;
using System.Linq;
using Infra.Persistence.Context;
using Application.Common.Interfaces.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Common.Entities;
using Domain.Common.Models;

namespace Infra.Persistence.Repository
{
    public class PedidosRepository : IPedidosRepository
    {
        private EntityContext _context;

        public PedidosRepository(EntityContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VPedidosModel>> PedidosAsync(int pageSize = 20, int page = 1)
        {


            var viewPedido = await _context.VPedidos
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .OrderBy(p => p.DataInclusao)
                                    .ToListAsync();

            var res = from vp in viewPedido
                      group vp by new
                      {
                          vp.PedidoId,
                          vp.DataInclusao,
                          vp.DataEntrega,
                          vp.EnderecoId,
                          vp.Endereco,
                          vp.EstadoId,
                          vp.Estado,
                          vp.CidadeId,
                          vp.Cidade,
                          vp.Cep,
                          vp.Uf
                      } into g1
                      join produto in viewPedido on g1.Key.PedidoId equals produto.PedidoId into produtos
                      select new VPedidosModel
                      {
                          PedidoId = g1.Key.PedidoId,
                          DataInclusao = g1.Key.DataInclusao,
                          DataEntrega = g1.Key.DataEntrega,
                          Endereco = new VEnderecoModel
                                        {
                                            EnderecoId = g1.Key.EnderecoId,
                                            Endereco = g1.Key.Endereco,
                                            EstadoId = g1.Key.EstadoId,
                                            Estado = g1.Key.Estado,
                                            CidadeId = g1.Key.CidadeId,
                                            Cidade = g1.Key.Cidade,
                                            Cep = g1.Key.Cep,
                                            Uf = g1.Key.Uf,
                                        },
                          Produtos = (from p in produtos
                                      select new Produto 
                                      {
                                          Id = p.ProdutoId.Value,
                                          Nome = p.Produto,
                                          Descricao = p.DescricaoProduto,
                                          Valor = p.ValorProduto.Value
                                      }).ToList()
                      };

            return res;
        }
    }
}