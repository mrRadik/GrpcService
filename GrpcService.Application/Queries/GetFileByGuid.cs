using AutoMapper;
using GrpcService.Application.Interfaces;
using GrpcService.Application.Models;
using GrpcService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Queries;

public record GetFileByGuidQuery(Guid FileGuid) : IRequest<FileDto?>
{
}

public class GetFileByGuidQueryHandler(IDbContext context, IMapper mapper) : IRequestHandler<GetFileByGuidQuery, FileDto?>
{

    public async Task<FileDto?> Handle(GetFileByGuidQuery request, CancellationToken cancellationToken)
    {
        var fileEntity = await context.Files.AsNoTracking().FirstOrDefaultAsync(x => x.Guid == request.FileGuid, cancellationToken);
        if (fileEntity == null)
        {
            return await Task.FromResult(new FileDto());
        }

        return mapper.Map<FileDto>(fileEntity);

    }
}