using GrpcService.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Commands;

public record DeleteFileCommand(Guid Guid) : IRequest;

public class DeleteFileCommandHandler(IDbContext context) : IRequestHandler<DeleteFileCommand>
{
    public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var file = await context.Files.FirstOrDefaultAsync(x => x.Guid == request.Guid, cancellationToken);

        if (file == null)
        {
            return;
        }

        context.Files.Remove(file);
        await context.SaveChangesAsync(cancellationToken);
    }
}