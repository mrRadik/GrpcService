using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace GrpcService.CodeFirst.Shared.Contracts;

[DataContract]
public class MailRequest
{
    [DataMember(Order = 1)]
    public string MailTo { get; set; }
    
    [DataMember(Order = 2)]
    public string MailFrom { get; set; }
    
    [DataMember(Order = 3)]
    public string Subject { get; set; }
    
    [DataMember(Order = 4)]
    public string Body { get; set; }
    
    [DataMember(Order = 5)]
    public FileAttachment File { get; set; }
    
}

[DataContract]
public class FileAttachment
{
    [DataMember(Order = 1)]
    public string FileName { get; set; }
    
    [DataMember(Order = 2)]
    public byte[] FileData { get; set; }
}

[DataContract]
public class MailReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}

[ServiceContract]
public interface IMailService
{
    [OperationContract]
    Task<MailReply> SendEmailAsync(MailRequest request, CallContext context = default);
}