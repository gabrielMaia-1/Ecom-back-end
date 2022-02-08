using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEntityContext
    {
        DbSet<Cidade> Cidade { get; }
        DbSet<Endereco> Endereco { get; }
        DbSet<Equipe> Equipe { get; }
        DbSet<Estado> Estado { get; }
        DbSet<Pedido> Pedido { get; }
        DbSet<PedidoProduto> PedidoProduto { get; }
        DbSet<Produto> Produto { get; }
        DbSet<Veiculo> Veiculo { get; }
    }
}