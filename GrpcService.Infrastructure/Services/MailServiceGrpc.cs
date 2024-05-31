using System.Net.Mail;
using System.Net.Mime;
using GrpcService.CodeFirst.Shared.Contracts;
using ProtoBuf.Grpc;

namespace GrpcService.Infrastructure.Services;

public class MailServiceGrpc : IMailService
{
    private readonly SmtpClient _client;

    public MailServiceGrpc(SmtpClient client)
    {
        _client = client;
    }
    public async Task<MailReply> SendEmailAsync(MailRequest request, CallContext context = default)
    {
        var mailReply = new MailReply();
        try
        {
            await _client.SendMailAsync(CreateMessage(request));
            mailReply.Message = "Сообщение успешно отправлено";
        }
        catch (Exception ex)
        {
            mailReply.Message = $"При отправке сообщения произошла ошибка: {ex.Message}";
        }
        
        return await Task.FromResult(mailReply);
    }

    private static MailMessage CreateMessage(MailRequest request)
    {
        var ms = new MemoryStream(request.File.FileData);
        var attachment = new Attachment(ms, new ContentType())
        {
            Name = request.File.FileName
        };
        
        return new MailMessage(request.MailFrom, request.MailTo)
        {
            Subject = request.Subject,
            Body = request.Body,
            Attachments = { attachment }
        };
    }
}