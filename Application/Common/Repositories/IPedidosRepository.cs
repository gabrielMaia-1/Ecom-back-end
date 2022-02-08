using Domain.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IPedidosRepository
    {
        Task<IEnumerable<VPedidosModel>> PedidosAsync(int pageSize, int page);
    }
}