using GrpcService.Application.Interfaces;
using GrpcService.CodeFirst.Shared;
using GrpcService.Infrastructure.Data;
using GrpcService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcService.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
        var connectionString = configuration.GetConnectionString(connectionStringName);
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddDbContext<PostgreContext>((sp,o) =>
        {
            o.UseNpgsql(connectionString);
            o.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<PostgreContext>());
        services.AddScoped<IFakeFileStorage, FakeFileStorage>();
        services.AddEntityFrameworkNpgsql();
        services.AddGrpc();
        services.AddCodeFirst();
        
        return services;
    }
}