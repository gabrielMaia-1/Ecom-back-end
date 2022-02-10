using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Models
{
    public class EnderecoModel
    {
        public int EnderecoId { get; set; }
        public string Endereco { get; set; }
        public int CidadeId { get; set; }
        public string Cidade { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
    }
}
