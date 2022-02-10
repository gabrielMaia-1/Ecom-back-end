namespace Domain.Common.Models
{
    public class RankProduto
    {
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal TicketMedio { get; set; }
    }
}