using MediatR;
using Microsoft.Extensions.Logging;

namespace GrpcService.Application.Behaviours;

public class ExceptionBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            logger.LogError(ex, "Произошла ошибка при выполнении запроса {Name} {@Request}", requestName, request);
            throw;
        }
    }
}