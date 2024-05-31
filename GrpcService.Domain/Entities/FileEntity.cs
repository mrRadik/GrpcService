using GrpcService.Domain.Events;

namespace GrpcService.Domain.Entities;

public class FileEntity : BaseEntity
{
    public string Name { get; set; }
    
    public byte[] Data { get; set; }
    
    public DateTime CreationTime { get; set; } = DateTime.Now.ToUniversalTime();
    
    public string Extension { get; set; }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            return;
        }
        
        Name = newName;
        AddDomainEvents(new RenameFileEvent(this));
    }
    
}