namespace GrpcService.Application.Interfaces;

public interface IFakeFileStorage
{
    public Task RenameFile(Guid fileGuid, string newName);
}