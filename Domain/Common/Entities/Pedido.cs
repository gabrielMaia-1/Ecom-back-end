using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataEntrega { get; set; }
        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}
