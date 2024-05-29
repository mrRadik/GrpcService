using System.Reflection;
using GrpcService.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcService.Application;

public static class DI
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionBehaviour<,>));
        });

        return services;
    }
}