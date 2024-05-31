using System.Net;
using System.Net.Mail;
using GrpcService.Application;
using GrpcService.Infrastructure;
using GrpcService.Infrastructure.Services;
using GrpcService.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration, "DefaultConnection");
builder.Services.AddApplicationServices();

var smtpSettings = builder.Configuration.GetSection(nameof(SmtpSettings)).Get<SmtpSettings>();

if (smtpSettings.SmtpDeliveryMethod == (int)SmtpDeliveryMethod.SpecifiedPickupDirectory)
{
    Directory.CreateDirectory(smtpSettings.PickupDirectoryLocation);
}

builder.Services.AddTransient(_ => new MailServiceGrpc(new SmtpClient
{
    Host = smtpSettings.Host,
    Port = smtpSettings.Port,
    Credentials = new NetworkCredential(smtpSettings.UserName, smtpSettings.Password),
    EnableSsl = smtpSettings.IsSecured,
    DeliveryMethod = (SmtpDeliveryMethod)smtpSettings.SmtpDeliveryMethod,
    PickupDirectoryLocation = smtpSettings.PickupDirectoryLocation
}));

builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

app.MapGrpcService<FileServiceGrpc>();
app.MapGrpcService<MailServiceGrpc>();

app.Run();