using E_Commerce.Core.RepositoryContracts;
using E_Commerce.Infrastructure.DbContext;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace E_Commerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container.
    /// </summary> 
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TO DO: Add services to the IoC container
        // Infrastructure services often include data access, caching and other low-level components
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddScoped<IDbConnection>(sp =>
        {
            var cs = sp.GetRequiredService<IConfiguration>()
                       .GetConnectionString("PostgresConnection");

            return new NpgsqlConnection(cs);
        });
        services.AddTransient<DapperDbContext>();
        return services;
    }
}

