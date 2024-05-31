using GrpcService.Application.Commands;
using GrpcService.Application.Interfaces;
using MediatR;

namespace GrpcService.Application.Behaviours;

public class SaveContextBehaviour<TRequest, TResponse>(IDbContext context) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next.Invoke();

        if (typeof(TRequest).GetInterface(nameof(IBaseCommand)) != null)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        
        return response;
    }
}