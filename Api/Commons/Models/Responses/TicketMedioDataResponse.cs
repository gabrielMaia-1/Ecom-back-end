using System;

namespace Api.Commons.Models.Dtos
{
    public class TicketMedioDataResponse
    {
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal TicketMedio { get; set; }
    }
}