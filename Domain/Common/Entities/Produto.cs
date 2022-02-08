using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Produto
    {
        public Produto()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}
