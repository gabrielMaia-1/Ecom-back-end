using Domain.Common.Entities;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Cidade> Cidade { get; }
        IRepository<Endereco> Endereco { get; }
        IRepository<Estado> Estado { get; }
        IRepository<Produto> Produto { get; }
        IRepository<Veiculo> Veiculo { get; }
        IRepository<Pedido> Pedido { get; }
        IRepository<PedidoProduto> PedidoProduto { get; }
        IRepository<Equipe> Equipe { get; }
        int Complete();
    }
}