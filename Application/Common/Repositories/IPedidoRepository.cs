using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common.Entities;
using Domain.Common.Models;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<(IEnumerable<FatoPedidosModel> Pedidos, int Count)> GetPedidosPaginadoAsync(int page, int pageSize);
        Task<IEnumerable<TicketMedioData>> GetTicketMedData();
        Task<IEnumerable<TicketMedioCidade>> GetTicketMedCidade();
        Task<IEnumerable<RankProduto>> GetRankProduto();
    }
}