namespace Api.Commons.Models.Dtos
{
    public class EnderecoResponse
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