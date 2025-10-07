using Test003.Core.Domain.Configuration;

namespace Test003.Core.Application;

/// <summary>
/// Provides initialization and configuration for the application at runtime.
/// </summary>
public static class ApplicationManager
{
    /// <summary>
    /// Initializes the application with the required middleware and settings.
    /// </summary>
    /// <param name="app">The WebApplication instance to be configured.</param>
    public static void InitApplication(ref WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.EnvironmentName == AppEnvironment.Development)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "NETCore Base API v1"));
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}