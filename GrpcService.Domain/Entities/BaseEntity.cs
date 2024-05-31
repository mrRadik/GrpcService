using GrpcService.Domain.Events;

namespace GrpcService.Domain.Entities;

public class BaseEntity
{
    private readonly List<IBaseEvent> _domainEvents = new();
    
    public int Id { get; set; }
    
    public Guid Guid { get; set; } = Guid.NewGuid();

    public IReadOnlyCollection<IBaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvents(IBaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}