namespace Api.Commons.Models.Dtos
{
    public class TicketMedioCidadeResponse
    {
        public int CidadeId { get; set; }
        public string Cidade { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal TicketMedio { get; set; }
    }
}