using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VeiculoId { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}
