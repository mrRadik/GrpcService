using GrpcService.Application.Interfaces;
using GrpcService.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GrpcService.Application.EventHandlers;

public class RenameFileEventHandler(IFakeFileStorage fileStorage, ILogger<RenameFileEventHandler> logger) : INotificationHandler<RenameFileEvent>
{
    public Task Handle(RenameFileEvent notification, CancellationToken cancellationToken)
    {
        var file = notification.File;
        
        fileStorage.RenameFile(file.Guid, file.Name);
        logger.LogInformation($"Файл {file.Name} был переименован");
        
        return Task.CompletedTask;
    }
}