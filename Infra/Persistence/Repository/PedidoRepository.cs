using System.Collections.Generic;
using System.Linq;
using Infra.Persistence.Context;
using Application.Common.Interfaces.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Common.Entities;
using Domain.Common.Models;
using System.Linq.Expressions;
using System;

namespace Infra.Persistence.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private EntityContext _context;

        public PedidoRepository(EntityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<FatoPedidosModel> Pedidos, int Count)> GetPedidosPaginadoAsync(int page = 1, int pageSize = 10)
        {
            
            
            var query =   from ped in _context.Pedido
                            select new FatoPedidosModel 
                            {
                                PedidoId = ped.Id,
                                DataInclusao = ped.DataInclusao,
                                DataEntrega= ped.DataEntrega,
                                Endereco = new EnderecoModel
                                {
                                    EnderecoId = ped.Endereco.Id,
                                    Endereco = ped.Endereco.Nome,
                                    CidadeId = ped.Endereco.CidadeId,
                                    Cidade = ped.Endereco.Cidade.Nome,
                                    EstadoId = ped.Endereco.Cidade.EstadoId,
                                    Estado = ped.Endereco.Cidade.Estado.Nome,
                                    Cep = ped.Endereco.Cep,
                                    Uf = ped.Endereco.Cidade.Estado.Uf
                                }
                            };

            var count = await _context.Pedido.CountAsync();

            var pedidos = await query.AsNoTracking()
                .OrderBy(p => p.DataInclusao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var idPedidos = _context.Pedido
                .OrderBy(p => p.DataInclusao)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => p.Id);

            var produtos =  await (from produto in _context.PedidoProduto
                            where idPedidos.Contains(produto.IdPedido)
                            select new
                            {
                                produto.IdPedido,
                                produto.IdProdutoNavigation.Id,
                                produto.IdProdutoNavigation.Nome,
                                produto.IdProdutoNavigation.Descricao,
                                produto.IdProdutoNavigation.Valor
                            }).AsNoTracking().ToListAsync();
            

            foreach (var pedido in pedidos)
            {
                var produtosPedido = produtos.Where(p => p.IdPedido == pedido.PedidoId)
                    .Select(o => {
                        return new Produto
                        {
                            Id = o.Id,
                            Nome = o.Nome,
                            Descricao = o.Descricao,
                            Valor = o.Valor
                        };
                    });

                pedido.Produtos.AddRange(produtosPedido);
            }

            return (Pedidos: pedidos.AsEnumerable(), Count:  count);
        }

        public async Task<IEnumerable<TicketMedioData>> GetTicketMedData()
        {
            var ticket =    from p in _context.VPedidos
                            group p by p.DataInclusao into g1
                            select new TicketMedioData
                            {
                                Data = g1.Key.Value,
                                Quantidade = g1.Count(),
                                Valor = g1.Sum(v => v.ValorProduto.Value),
                                TicketMedio = (g1.Sum(v => v.ValorProduto.Value) / g1.Count())
                            };
            return (await ticket.AsNoTracking().ToListAsync()).AsEnumerable();
        }

        public async Task<IEnumerable<TicketMedioCidade>> GetTicketMedCidade()
        {
            var ticket =    from p in _context.VPedidos
                            group p by new { p.CidadeId, p.Cidade } into g1
                            select new TicketMedioCidade
                            {
                                CidadeId = g1.Key.CidadeId.Value,
                                Cidade = g1.Key.Cidade,                                
                                Quantidade = g1.Count(),
                                Valor = g1.Sum(v => v.ValorProduto.Value),
                                TicketMedio = (g1.Sum(v => v.ValorProduto.Value) / g1.Count())
                            };

            return (await ticket.AsNoTracking().ToListAsync()).AsEnumerable();
        }
        public async Task<IEnumerable<RankProduto>> GetRankProduto()
        {
            var ticket =    from p in _context.VPedidos
                            group p by new { p.ProdutoId, p.Produto, p.DescricaoProduto } into g1
                            select new RankProduto
                            {                           
                                ProdutoId = g1.Key.ProdutoId.Value,
                                Produto = g1.Key.Produto,
                                Descricao = g1.Key.DescricaoProduto,
                                Quantidade = g1.Count(),
                                Valor = g1.Sum(v => v.ValorProduto.Value),
                                TicketMedio = (g1.Sum(v => v.ValorProduto.Value) / g1.Count())
                            };
                            
            return (await ticket.AsNoTracking().ToListAsync()).AsEnumerable();
        }
    }
}