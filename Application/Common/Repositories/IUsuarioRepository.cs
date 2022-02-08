using Domain.Common.Entities;

namespace Application.Common.Interfaces.Repositories
{   
    public interface IUsuarioRepository
    {
        Usuario GetUser(string username, string password);
    }
}