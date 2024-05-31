using System.Reflection;
using GrpcService.Application.Interfaces;
using GrpcService.CodeFirst.Shared;
using GrpcService.Infrastructure.Behaviours;
using GrpcService.Infrastructure.Data;
using GrpcService.Infrastructure.Services;
using MediatR;
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
        services.AddDbContext<PostgreContext>((sp,o) =>
        {
            o.UseNpgsql(connectionString);
        });
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<PostgreContext>());
        services.AddScoped<IFakeFileStorage, FakeFileStorage>();
        services.AddEntityFrameworkNpgsql();
        services.AddGrpc();
        services.AddCodeFirst();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(SaveContextBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(DomainEventDispatchBehaviour<,>));
        });
        
        return services;
    }
}