using Microsoft.EntityFrameworkCore;
using Test003.Core.Application.Interfaces;
using Test003.Core.Application.Services;
using Test003.Core.Domain.Configuration;
using Test003.Infrastructure.Persistence.DbContexts;

namespace Test003.Core.Application;

/// <summary>
/// Provides a centralized mechanism to register various application services into the service container.
/// </summary>
public static class ServiceManager
{
    /// <summary>
    /// Registers application services into the service container
    /// </summary>
    /// <param name="builder">The application builder</param>
    public static void RegisterServices(ref WebApplicationBuilder builder)
    {
        #region Application Services

        builder.Services.AddControllers(); // Add services to the container.
        builder.Services
            .AddEndpointsApiExplorer(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();

        #endregion

        #region Singleton Services

        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        // builder.Services.AddDbContextFactory<PsqlDbContext>(x =>
        //     x.UseNpgsql(AppEnvironment.ConfigurationMap?.ConnectionStringValue("DefaultConnection")));

        builder.Services.AddSingleton<ILoggingService, LoggingService>();

        #endregion

        #region Scoped Services

        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddDbContext<PsqlDbContext>(x => x.UseNpgsql(connectionString));

        builder.Services.AddScoped<IPhoneService, PhoneService>();
        #endregion

        #region Transient Services

        #endregion
    }
}