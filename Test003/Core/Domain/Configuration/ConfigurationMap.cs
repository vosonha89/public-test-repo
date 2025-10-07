namespace Test003.Core.Domain.Configuration;

using Microsoft.Extensions.Configuration;

/// <summary>
/// Represents a helper class that facilitates access to configuration values
/// stored within an <see cref="IConfiguration" /> instance. Enables retrieval of
/// configuration values, sections, and connection strings while supporting both
/// basic and strongly-typed access.
/// </summary>
public class ConfigurationMap
{
    private readonly IConfigurationManager _configurationManager;

    public ConfigurationMap(IConfigurationManager configuration)
    {
        _configurationManager = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Gets a configuration value by key
    /// </summary>
    /// <param name="key">The configuration key (supports nested keys with ':' separator)</param>
    /// <returns>The configuration value as string, or null if not found</returns>
    public string? Value(string key)
    {
        return _configurationManager[key];
    }

    /// <summary>
    /// Gets a configuration value by key with a default value
    /// </summary>
    /// <param name="key">The configuration key</param>
    /// <param name="defaultValue">Default value if the key is not found</param>
    /// <returns>The configuration value or default value</returns>
    public string Value(string key, string defaultValue)
    {
        return _configurationManager[key] ?? defaultValue;
    }

    /// <summary>
    /// Gets a strongly typed configuration value
    /// </summary>
    /// <typeparam name="T">The type to convert the value to</typeparam>
    /// <param name="key">The configuration key</param>
    /// <returns>The converted value, or default(T) if not found or conversion fails</returns>
    public T? Value<T>(string key)
    {
        return _configurationManager.GetValue<T>(key);
    }

    /// <summary>
    /// Gets a strongly typed configuration value with a default
    /// </summary>
    /// <typeparam name="T">The type to convert the value to</typeparam>
    /// <param name="key">The configuration key</param>
    /// <param name="defaultValue">Default value if the key is not found</param>
    /// <returns>The converted value or default value</returns>
    public T? Value<T>(string key, T defaultValue)
    {
        return _configurationManager.GetValue(key, defaultValue);
    }

    /// <summary>
    /// Gets a configuration section
    /// </summary>
    /// <param name="key">The section key</param>
    /// <returns>The configuration section</returns>
    public IConfigurationSection SectionValue(string key)
    {
        return _configurationManager.GetSection(key);
    }

    /// <summary>
    /// Binds a configuration section to a strongly typed object
    /// </summary>
    /// <typeparam name="T">The type to bind to</typeparam>
    /// <param name="key">The section key</param>
    /// <returns>The bound object instance</returns>
    public T SectionValue<T>(string key) where T : new()
    {
        var section = new T();
        _configurationManager.GetSection(key).Bind(section);
        return section;
    }

    /// <summary>
    /// Gets a connection string by name
    /// </summary>
    /// <param name="name">The connection string name</param>
    /// <returns>The connection string value</returns>
    public string? ConnectionStringValue(string name)
    {
        return _configurationManager.GetConnectionString(name);
    }

    /// <summary>
    /// Checks if a configuration key exists
    /// </summary>
    /// <param name="key">The configuration key</param>
    /// <returns>True if the key exists, false otherwise</returns>
    public bool HasKey(string key)
    {
        return _configurationManager[key] is not null;
    }

    /// <summary>
    /// Gets all configuration keys that start with the specified prefix
    /// </summary>
    /// <param name="prefix">The key prefix</param>
    /// <returns>Dictionary of matching keys and values</returns>
    public Dictionary<string, string?> ValueByPrefix(string prefix)
    {
        var result = new Dictionary<string, string?>();
        var section = _configurationManager.GetSection(prefix);

        foreach (var child in section.GetChildren())
        {
            result[child.Key] = child.Value;
        }

        return result;
    }
}