using Test003.Core.Application;
using Test003.Core.Domain.Configuration;

var builder = WebApplication.CreateBuilder(args);
AppEnvironment.ApplyConfig(ref builder);
ServiceManager.RegisterServices(ref builder);

var app = builder.Build();
ApplicationManager.InitApplication(ref app);
await app.RunAsync();