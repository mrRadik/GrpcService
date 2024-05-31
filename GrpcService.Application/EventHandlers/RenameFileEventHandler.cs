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
        
        //сделано в качесте тестового примера. в реальном проекте так делать не стоит, потому что это идет до сохранения
        //контекста БД и если что то пойдет не так, то будет расхождение данных. Можно посмотреть в сторону шины
        fileStorage.RenameFile(file.Guid, file.Name);
        logger.LogInformation($"Файл {file.Name} был переименован");
        
        return Task.CompletedTask;
    }
}