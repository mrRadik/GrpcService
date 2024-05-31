using Google.Protobuf;
using Grpc.Net.Client;
using GrpcService.FileServiceClient.Models;
using Microsoft.Extensions.Options;
using File = GrpcService.FileServiceClient.Models.File;

namespace GrpcService.FileServiceClient.Services;

internal class FileService : IFileService
{
    private readonly FileServiceClient.FileService.FileServiceClient _client;
    
    public FileService(IOptions<GrpcClientSettings> options)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        
        var clientSettings = options.Value;
        var chanel = GrpcChannel.ForAddress($"{clientSettings.Url}:{clientSettings.Port}", new GrpcChannelOptions{HttpHandler = handler});
        _client = new FileServiceClient.FileService.FileServiceClient(chanel);
    }
    
    public async Task<File> GetFile(string guid)
    {
        var getFileResponse = new GetFileRequest
        {
            FileGuid = guid
        };
        
        return Map(await _client.GetFileAsync(getFileResponse));
    }

    public async Task<List<File>> GetAllFiles()
    {
        var filesResponse = await _client.GetAllFilesAsync(new GetAllFilesRequest());
        return filesResponse.Files.Select(Map).ToList();
    }

    public async Task AddFile(File file)
    {
        var addFileRequest = new CreateFileRequest
        {
            Data = ByteString.CopyFrom(file.Data),
            Extension = file.Extension,
            FileName = file.Name
        };
        
        await _client.CreateFileAsync(addFileRequest);
    }

    public async Task DeleteFile(string guid)
    {
        var deleteFileRequest = new DeleteFileRequest
        {
            FileGuid = guid
        };

        await _client.DeleteFileAsync(deleteFileRequest);
    }

    public async Task RenameFile(string guid, string newName)
    {
        var renameFileRequest = new RenameFileRequest
        {
            NewFileName = newName,
            Guid = guid
        };
        
        await _client.RenameFileAsync(renameFileRequest);
    }

    private File Map(GetFileResponse file)
    {
        return new File
        {
            Name = file.FileName,
            Extension = file.Extension,
            FileGuid = new Guid(file.Guid),
            CreationTime = file.CreationDate.ToDateTime(),
            Data = file.Data.ToByteArray()
        };
    }
}