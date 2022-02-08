using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Endereco
    {
        public Endereco()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public string Cep { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
