using GrpcService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Commands;

public record RenameFileCommand(string NewName, Guid FileGuid) : IRequest, IBaseCommand;

public class RenameFileHandler(IDbContext context) : IRequestHandler<RenameFileCommand>
{
    public async Task Handle(RenameFileCommand request, CancellationToken cancellationToken)
    {
        var file = await context.Files.FirstOrDefaultAsync(x => x.Guid == request.FileGuid, cancellationToken);
        file?.Rename(request.NewName);
    }
}