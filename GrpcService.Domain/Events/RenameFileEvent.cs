using GrpcService.Domain.Entities;

namespace GrpcService.Domain.Events;

public class RenameFileEvent : IBaseEvent
{
    public FileEntity File { get; set; }

    public RenameFileEvent(FileEntity file)
    {
        File = file;
    }
}