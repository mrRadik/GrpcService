using GrpcService.Application.Interfaces;
using GrpcService.Domain.Entities;
using MediatR;

namespace GrpcService.Application.Commands;

public struct CreateFileCommand : IRequest<int>
{
    public string FileName { get; set; }
    
    public string FileExtension { get; set; }
    
    public byte[] FileData { get; set; }
}

public class CreateFileCommandHandler(IDbContext context) : IRequestHandler<CreateFileCommand, int>
{
    public async Task<int> Handle(CreateFileCommand request, CancellationToken cancellationToken)
    {
        var file = new FileEntity
        {
            Name = request.FileName,
            Data = request.FileData,
            Extension = request.FileExtension,
        };

        context.Files.Add(file);
        await context.SaveChangesAsync(cancellationToken);

        return file.Id;
    }
}