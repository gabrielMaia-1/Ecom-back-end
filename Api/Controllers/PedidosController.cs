using System.Threading.Tasks;
using Domain.Common.Entities;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
using Api.Commons.Models.Dtos;
using Domain.Common.Models;

namespace Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidosResponse>>>
            GetAll( [FromServices] IPedidoRepository repo,
                                                [FromServices] IMapper mapper,
                                                [FromQuery(Name = "pageSize")] int pageSize = 10,
                                                [FromQuery(Name = "page")] int page = 1)
        {
            var pedidos = await repo.GetPedidosPaginadoAsync(page, pageSize);
            var res = new PedidosPagedResponse
            {
                Count = pedidos.Count,
                Pedidos = mapper.Map<IEnumerable<PedidosResponse>>(pedidos.Pedidos)
            };

            return Ok(res);
        }

        [HttpGet("ticketMedio/data")]
        public async Task<ActionResult<IEnumerable<TicketMedioData>>>
            GetTicketMedData([FromServices] IPedidoRepository repo,
                            [FromServices] IMapper mapper)
        {
         return Ok(mapper.Map<TicketMedioDataResponse[]>(await repo.GetTicketMedData()));   
        }
        [HttpGet("ticketMedio/cidade")]
        public async Task<ActionResult<IEnumerable<TicketMedioCidade>>>
            GetTicketMedCidade([FromServices] IPedidoRepository repo,
                            [FromServices] IMapper mapper)
        {
         return Ok(mapper.Map<TicketMedioCidadeResponse[]>(await repo.GetTicketMedCidade()));   
        }

        [HttpGet("rankProdutos")]
        public async Task<ActionResult<IEnumerable<RankProduto>>>
            GetrankProdutos([FromServices] IPedidoRepository repo,
                            [FromServices] IMapper mapper)
        {
         return Ok(mapper.Map<RankProdutoResponse[]>(await repo.GetRankProduto()));   
        }
    }
}