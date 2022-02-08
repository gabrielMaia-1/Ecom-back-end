using System.Linq;
using Application.Common.Interfaces.Repositories;
using Domain.Common.Entities;
using Infra.Persistence.Context;

namespace Infra.Persistence.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository(EntityContext context)
        {
            _context = context;
        }

        public EntityContext _context { get; }

        public Usuario GetUser(string username, string password)
        {
            return _context.Usuario
                            .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}