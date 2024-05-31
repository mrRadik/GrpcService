using GrpcService.Application.Interfaces;
using GrpcService.CodeFirst.Shared;
using GrpcService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcService.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetConnectionString(connectionStringName);
        services.AddDbContext<PostgreContext>(c => c.UseNpgsql(connectionString));
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<PostgreContext>());
        services.AddEntityFrameworkNpgsql();
        services.AddGrpc();
        services.AddCodeFirst();
        
        return services;
    }
}