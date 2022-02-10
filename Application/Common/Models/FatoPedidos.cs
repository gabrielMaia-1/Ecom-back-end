using Domain.Common.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Common.Models
{
    public class FatoPedidos
    {
        public FatoPedidos()
        {   
            Produtos = new List<Produto>();
        }
        
        public int? PedidoId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public DimensaoEndereco Endereco { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
