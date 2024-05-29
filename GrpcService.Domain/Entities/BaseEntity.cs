namespace GrpcService.Domain.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    
    public Guid Guid { get; set; } = Guid.NewGuid();
}