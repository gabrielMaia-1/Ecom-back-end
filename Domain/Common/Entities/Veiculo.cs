using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Common.Entities
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Equipe = new HashSet<Equipe>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }

        public virtual ICollection<Equipe> Equipe { get; set; }
    }
}
