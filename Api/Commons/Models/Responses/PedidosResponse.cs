using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Commons.Models.Dtos
{
    public class PedidosResponse
    {
        public int PedidoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataEntrega { get; set; }
        public EnderecoResponse Endereco { get; set; }
        public List<ProdutoResponse> Produtos { get; set; }
    }
}
