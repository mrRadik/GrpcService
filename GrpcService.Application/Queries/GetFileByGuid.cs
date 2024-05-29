using GrpcService.Application.Interfaces;
using GrpcService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Queries;

public record GetFileByGuidQuery(Guid FileGuid) : IRequest<FileEntity?>
{
}

public class GetFileByGuidQueryHandler(IDbContext context) : IRequestHandler<GetFileByGuidQuery, FileEntity?>
{
    private readonly IDbContext _context = context;

    public async Task<FileEntity?> Handle(GetFileByGuidQuery request, CancellationToken cancellationToken)
    {
        return await _context.Files
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Guid == request.FileGuid, cancellationToken);
    }
}