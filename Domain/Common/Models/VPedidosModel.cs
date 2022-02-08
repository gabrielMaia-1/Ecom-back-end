using Domain.Common.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Models
{
    public class VPedidosModel
    {
        public int? PedidoId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public VEnderecoModel Endereco { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
