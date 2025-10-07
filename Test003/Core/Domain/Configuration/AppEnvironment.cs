namespace Test003.Core.Domain.Configuration;

/// <summary>
/// Represents the application environment constants.
/// </summary>
public static class AppEnvironment
{
    public const string Development = "Development";
    public const string Staging = "Staging";
    public const string Production = "Production";
    
    public static ConfigurationMap? ConfigurationMap { get; private set; }


    /// <summary>
    /// Apply application config
    /// </summary>
    /// <param name="builder"></param>
    public static void ApplyConfig(ref WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile(
            $"Environment/appsettings.{builder.Environment.EnvironmentName}.json",
            optional: false,
            reloadOnChange: true);

        ConfigurationMap = new ConfigurationMap(builder.Configuration);
    }
}