using GrpcService.Application.Commands;
using GrpcService.Domain.Entities;
using GrpcService.Infrastructure.Data;
using MediatR;

namespace GrpcService.Infrastructure.Behaviours;

public class DomainEventDispatchBehaviour<TRequest, TResponse>(IMediator mediator, PostgreContext? context) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        
        if (request is IBaseCommand)
        {
            try
            {
                await DispatchDomainEvents(cancellationToken);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        return response;
    }
    
    private async Task DispatchDomainEvents(CancellationToken cancellationToken)
    {
        if (context == null)
        {
            return;
        }

        var entities = context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
            
    }
}