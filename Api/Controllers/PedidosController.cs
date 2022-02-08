using System.Threading.Tasks;
using Domain.Common.Entities;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;
using Api.Commons.Models.Dtos;

namespace Api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VPedidosResponse>>>
            GetAll( [FromServices] IPedidosRepository repo,
                                                [FromServices] IMapper mapper,
                                                [FromQuery(Name = "pageSize")] int pageSize = 20,
                                                [FromQuery(Name = "page")] int page = 1)
        {
            return Ok(mapper.Map<IEnumerable<VPedidosResponse>>(await repo.PedidosAsync(pageSize, page)));
        }

    }
}