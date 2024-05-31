using GrpcService.FileServiceClient.Models;
using GrpcService.FileServiceClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GrpcService.FileServiceClient;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        var host = Host.CreateDefaultBuilder().ConfigureServices((builder,services) =>
        {
            services.AddTransient<IFileService, Services.FileService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<frmMain>();
            services.Configure<GrpcClientSettings>(builder.Configuration.GetSection(nameof(GrpcClientSettings)));
        }).Build();

        Application.Run(host.Services.GetRequiredService<frmMain>());
    }
}