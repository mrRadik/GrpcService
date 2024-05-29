using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Application.Commands;
using GrpcService.Application.Queries;
using GrpcService.Domain.Entities;
using MediatR;

namespace GrpcService.Infrastructure.Services;

public class FileServiceGrpc(ISender mediator) : FileService.FileServiceBase
{
    public override async Task<CreateFileResponse> CreateFile(CreateFileRequest request, ServerCallContext context)
    {
        var createFileCommand = new CreateFileCommand
        {
            FileName = request.FileName,
            FileData = request.Data.ToByteArray(),
            FileExtension = request.Extension
        };

        var fileId = await mediator.Send(createFileCommand, context.CancellationToken);
        
        return await Task.FromResult(new CreateFileResponse
        {
            FileId = fileId
        });
    }

    public override async Task<DeleteFileResponse> DeleteFile(DeleteFileRequest request, ServerCallContext context)
    {
        var deleteFileCommand = new DeleteFileCommand(new Guid(request.FileGuid));

        await mediator.Send(deleteFileCommand, context.CancellationToken);

        return await Task.FromResult(new DeleteFileResponse());
    }

    public override async Task<GetFileResponse> GetFile(GetFileRequest request, ServerCallContext context)
    {
        var getFileQuery = new GetFileByGuidQuery(new Guid(request.FileGuid));
        var file = await mediator.Send(getFileQuery, context.CancellationToken);

        return await Task.FromResult(MapFileToResponse(file));
    }

    public override async Task<GetAllFilesResponse> GetAllFiles(GetAllFilesRequest request, ServerCallContext context)
    {
        var getAllFilesQuery = new GetAllFilesQuery();
        try
        {
            var files = await mediator.Send(getAllFilesQuery, context.CancellationToken);
            var result = new GetAllFilesResponse();

            foreach (var file in files)
            {
                result.Files.Add(MapFileToResponse(file));
            }

            return await Task.FromResult(result);
        }
        catch(Exception ex)
        {
            var a = ex.Message;
        }

        return await Task.FromResult(new GetAllFilesResponse());
    }

    private static GetFileResponse MapFileToResponse(FileEntity file)
    {
        var data = ByteString.CopyFrom(file.Data);
        return new GetFileResponse
        {
            FileName = file.Name,
            Extension = file.Extension,
            Data = data,
            Guid = file.Guid.ToString(),
            CreationDate = file.CreationTime.ToTimestamp()
        };
    }
}