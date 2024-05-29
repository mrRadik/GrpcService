using GrpcService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcService.Application.Interfaces;

public interface IDbContext
{
    DbSet<FileEntity> Files { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}