using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Commons.Models.Dtos
{
    public class PedidosPagedResponse
    {
        public int Count { get; set; }
        public IEnumerable<PedidosResponse> Pedidos { get; set; }
    }
}
