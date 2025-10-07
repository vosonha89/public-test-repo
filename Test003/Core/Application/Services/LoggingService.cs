using Test003.Core.Application.Interfaces;

namespace Test003.Core.Application.Services;

/// <summary>
/// Simple implementation of the ILoggingService interface using Console.WriteLine
/// </summary>
public class LoggingService : ILoggingService
{
    /// <summary>
    /// Initializes a new instance of the LoggingService class
    /// </summary>
    public LoggingService()
    {
        // No dependencies needed for Console-based logging
    }

    /// <inheritdoc/>
    public void Debug(string message, params object[] args)
    {
        WriteToConsole("DEBUG", string.Format(message, args));
    }

    /// <inheritdoc/>
    public void Info(string message, params object[] args)
    {
        WriteToConsole("INFO", string.Format(message, args));
    }

    /// <inheritdoc/>
    public void Error(string message, params object[] args)
    {
        WriteToConsole("ERROR", string.Format(message, args));
    }

    /// <inheritdoc/>
    public void Error(Exception exception, string? message, params object[] args)
    {
        string formattedMessage = message is null ? string.Empty : string.Format(message, args);
        string exceptionMessage = $"{formattedMessage} Exception: {exception.Message}";

        if (exception.StackTrace is not null)
        {
            exceptionMessage += $"\nStackTrace: {exception.StackTrace}";
        }

        WriteToConsole("ERROR", exceptionMessage);
    }

    /// <summary>
    /// Write to the console
    /// </summary>
    /// <param name="level"></param>
    /// <param name="message"></param>
    private static void WriteToConsole(string level, string message)
    {
        var originalColor = Console.ForegroundColor;

        switch (level)
        {
            case "DEBUG":
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case "INFO":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "ERROR":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
        Console.ForegroundColor = originalColor;
    }
}