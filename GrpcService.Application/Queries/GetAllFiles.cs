using AutoMapper;
using AutoMapper.QueryableExtensions;
using GrpcService.Application.Interfaces;
using GrpcService.Application.Models;
using GrpcService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Queries;

public record GetAllFilesQuery : IRequest<List<FileDto>>;

public class GetAllFilesQueryHandler(IDbContext context, IMapper mapper) : IRequestHandler<GetAllFilesQuery, List<FileDto>>
{
    public async Task<List<FileDto>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
    {
        return await context.Files
            .AsNoTracking()
            .OrderBy(x=>x.Id)
            .ProjectTo<FileDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}