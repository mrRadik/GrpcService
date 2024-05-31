namespace GrpcService.Server.Models;

public class SmtpSettings
{
    public int SmtpDeliveryMethod { get; set; }
    public string PickupDirectoryLocation { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsSecured { get; set; }
}