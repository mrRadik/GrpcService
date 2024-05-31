using Grpc.Net.Client;
using GrpcService.CodeFirst.Shared.Contracts;
using GrpcService.FileServiceClient.Models;
using Microsoft.Extensions.Options;
using ProtoBuf.Grpc.Client;

namespace GrpcService.FileServiceClient.Services;

internal class EmailService : IEmailService
{
    private const string MAIL_FROM = "info@grpctest.net";
    
    private readonly IMailService _client;
    
    public EmailService(IOptions<GrpcClientSettings> options)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        
        var clientSettings = options.Value;
        var chanel = GrpcChannel.ForAddress($"{clientSettings.Url}:{clientSettings.Port}", new GrpcChannelOptions{HttpHandler = handler});
        
        _client = chanel.CreateGrpcService<IMailService>();
    }

    public async Task<string> SendEmail(EmailMessageDto message)
    {
        var mailRequest = new MailRequest
        {
            Body = message.Body,
            MailTo = message.MailTo,
            Subject = message.Subject,
            File = new FileAttachment
            {
                FileName = $"{message.File.Name}.{message.File.Extension}",
                FileData = message.File.Data
            },
            MailFrom = MAIL_FROM
        };

        var response = await _client.SendEmailAsync(mailRequest);

        return await Task.FromResult(response.Message);
    }
}