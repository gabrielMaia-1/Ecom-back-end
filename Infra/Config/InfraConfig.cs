
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Infra.Persistence.Repository;
using Domain.Common.Entities;
using Infra.Persistence.Context;
using Application.Common.Interfaces.Repositories;

namespace Infra.Config
{
    public static partial class InfraConfig
    {
        public static void ConfigInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EntityContext>(options => {
                options.UseNpgsql(config.GetConnectionString("Default"));
            });

            services.AddTransient(typeof(IRepository<Cidade>), typeof(Repository<Cidade>));

            services.AddTransient<IPedidosRepository, PedidosRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}