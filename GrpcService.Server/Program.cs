using GrpcService.Application;
using GrpcService.Infrastructure;
using GrpcService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureServices(builder.Configuration, "DefaultConnection");
builder.Services.AddApplicationServices();
builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

app.MapGrpcService<FileServiceGrpc>();
app.MapGet("/", () => "Hello World!");

app.Run();