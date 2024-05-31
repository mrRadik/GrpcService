using GrpcService.FileServiceClient.Models;

namespace GrpcService.FileServiceClient.Services;

internal interface IEmailService
{
    public Task<string> SendEmail(EmailMessageDto message);
}