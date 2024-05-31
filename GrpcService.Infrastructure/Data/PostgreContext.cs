using System.Reflection;
using GrpcService.Application.Interfaces;
using GrpcService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrpcService.Infrastructure.Data;

public class PostgreContext : DbContext, IDbContext
{
    public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
    {
    }

    public DbSet<FileEntity> Files => SetFile();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<FileEntity>(ConfigureFile);
    }

    private void ConfigureFile(EntityTypeBuilder<FileEntity> builder)
    {
        builder.ToTable("File");
        builder.HasKey(x => x.Id);
    }

    private DbSet<FileEntity> SetFile()
    {
        return Set<FileEntity>();
    }
}