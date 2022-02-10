using Domain.Common.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Models
{
    public class FatoPedidosModel
    {
        public FatoPedidosModel()
        {   
            Produtos = new List<Produto>();
        }
        
        public int? PedidoId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
