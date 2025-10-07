namespace Test003.Core.Application.Interfaces;

/// <summary>
/// Interface for a logging service to abstract logging implementation details from the application core
/// </summary>
public interface ILoggingService
{
    /// <summary>
    /// Logs a debug message
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="args">Optional format parameters</param>
    void Debug(string message, params object[] args);

    /// <summary>
    /// Logs an information message
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="args">Optional format parameters</param>
    void Info(string message, params object[] args);

    /// <summary>
    /// Logs an error message
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="args">Optional format parameters</param>
    void Error(string message, params object[] args);

    /// <summary>
    /// Logs an error message with exception details
    /// </summary>
    /// <param name="exception">The exception to log</param>
    /// <param name="message">Optional additional message</param>
    /// <param name="args">Optional format parameters</param>
    void Error(Exception exception, string message, params object[] args);
}