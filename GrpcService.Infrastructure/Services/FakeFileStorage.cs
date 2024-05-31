using GrpcService.Application.Interfaces;

namespace GrpcService.Infrastructure.Services;

public class FakeFileStorage : IFakeFileStorage
{
    public Task RenameFile(Guid fileGuid, string newName)
    {
        //какаято логика по доставанию файла с фхд и переименование
        return Task.CompletedTask;
    }
}