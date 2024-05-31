namespace GrpcService.FileServiceClient.Models;

internal class EmailMessageDto
{
    public string MailTo { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public File File { get; set; }
}