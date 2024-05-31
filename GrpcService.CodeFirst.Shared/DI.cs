using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

namespace GrpcService.CodeFirst.Shared;

public static class DI
{
    public static IServiceCollection AddCodeFirst(this IServiceCollection services)
    {
        services.AddCodeFirstGrpc();
        
        return services;
    }
}