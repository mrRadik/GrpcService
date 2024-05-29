using GrpcService.FileServiceClient.Models;
using File = GrpcService.FileServiceClient.Models.File;

namespace GrpcService.FileServiceClient.Services;

internal interface IFileService
{
    Task<File> GetFile(string guid);
    Task<List<File>> GetAllFiles();
    Task AddFile(File file);
    Task DeleteFile(string guid);
}