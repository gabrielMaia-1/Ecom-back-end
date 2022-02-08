using Domain.Common.Entities;
using Application.Common.Interfaces;
using Infra.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Persistence.Context;

namespace Infra.Persistence.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context;
        public IRepository<Cidade> Cidade { get; }
        public IRepository<Endereco> Endereco { get; }
        public IRepository<Estado> Estado { get; }
        public IRepository<Produto> Produto { get; }
        public IRepository<Veiculo> Veiculo { get; }
        public IRepository<Pedido> Pedido { get; }
        public IRepository<PedidoProduto> PedidoProduto { get; }
        public IRepository<Equipe> Equipe { get; }

        public UnitOfWork(EntityContext context)
        {
            _context = context;
            Cidade = new Repository<Cidade>(_context);
            Endereco = new Repository<Endereco>(_context);
            Estado = new Repository<Estado>(_context);
            Produto = new Repository<Produto>(_context);
            Veiculo = new Repository<Veiculo>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}