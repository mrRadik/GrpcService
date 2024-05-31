using GrpcService.Application.Commands;
using GrpcService.Application.Interfaces;
using MediatR;

namespace GrpcService.Infrastructure.Behaviours;

public class SaveContextBehaviour<TRequest, TResponse>(IDbContext context) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull 
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next.Invoke();

        if (request is IBaseCommand)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        
        return response;
    }
}