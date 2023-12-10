using Int.Application.Services.Repositories;
using Int.Persistence.Contexts;
using Int.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Int.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("InitialDb")));

        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}
