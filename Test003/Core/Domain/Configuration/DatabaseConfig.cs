namespace Test003.Core.Domain.Configuration;

/// <summary>
/// Database configuration
/// </summary>
public class DatabaseConfig
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string DatabaseName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Default constructor
    /// </summary>
    public DatabaseConfig()
    {
    }

    /// <summary>
    /// Constructor that parses connection string to set properties
    /// </summary>
    /// <param name="connectionString">Database connection string</param>
    public DatabaseConfig(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            return;

        var connectionParts = connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in connectionParts)
        {
            var keyValue = part.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);
            if (keyValue.Length != 2) continue;

            var key = keyValue[0].Trim().ToLowerInvariant();
            var value = keyValue[1].Trim();

            switch (key)
            {
                case "server":
                case "host":
                case "data source":
                    ParseHostAndPort(value);
                    break;
                case "port":
                    if (int.TryParse(value, out int port))
                        Port = port;
                    break;
                case "database":
                case "initial catalog":
                    DatabaseName = value;
                    break;
                case "user id":
                case "username":
                case "uid":
                    Username = value;
                    break;
                case "password":
                case "pwd":
                    Password = value;
                    break;
            }
        }
    }

    /// <summary>
    /// Parses host and port from a combined value like "localhost:5432"
    /// </summary>
    /// <param name="hostValue">Host value that may contain port</param>
    private void ParseHostAndPort(string hostValue)
    {
        var hostParts = hostValue.Split(':', StringSplitOptions.RemoveEmptyEntries);
        Host = hostParts[0];

        if (hostParts.Length > 1 && int.TryParse(hostParts[1], out int port))
        {
            Port = port;
        }
    }
}