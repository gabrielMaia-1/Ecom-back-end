using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class VFatoPedidos
    {
        public int? PedidoId { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int? EnderecoId { get; set; }
        public string Endereco { get; set; }
        public int? CidadeId { get; set; }
        public string Cidade { get; set; }
        public int? EstadoId { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public int? ProdutoId { get; set; }
        public string Produto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal? ValorProduto { get; set; }
    }
}
