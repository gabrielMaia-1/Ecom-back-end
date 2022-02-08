using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class PedidoProduto
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
