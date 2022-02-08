using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public int EstadoId { get; set; }
        public string Nome { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
