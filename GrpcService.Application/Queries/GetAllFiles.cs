using GrpcService.Application.Interfaces;
using GrpcService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Queries;

public record GetAllFilesQuery : IRequest<List<FileEntity>>;

public class GetAllFilesQueryHandler(IDbContext context) : IRequestHandler<GetAllFilesQuery, List<FileEntity>>
{
    public async Task<List<FileEntity>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
    {
        return await context.Files
            .AsNoTracking()
            .OrderBy(x=>x.Id)
            .ToListAsync(cancellationToken);
    }
}