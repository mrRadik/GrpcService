namespace GrpcService.FileServiceClient.Models;

internal class File
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public Guid FileGuid { get; set; }
    public DateTime CreationTime { get; set; }
    public byte[] Data { get; set; }
}