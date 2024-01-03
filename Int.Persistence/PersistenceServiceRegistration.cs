using Int.Application.Services.Repositories;
using Int.Identity.Repository.Service;
using Int.Identity.Service;
using Int.Persistence.Contexts;
using Int.Persistence.Repositories;
using Int.Utility.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Int.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("InitialDb")));

        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ILabelRepository, LabelRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHelper, JwtHelper>();

        return services;
    }
}
