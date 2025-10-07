namespace Test003.Core.Domain.Common.Base;

/// <summary>
/// Normal error message
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// Error code
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Error message
    /// </summary>
    public string Msg { get; set; } = string.Empty;
}

/// <summary>
/// Error definition for client side
/// </summary>
public class ClientError
{
    /// <summary>
    /// Error code identifier
    /// </summary>
    public string ErrorCode { get; set; } = string.Empty;

    /// <summary>
    /// Human-readable error message
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;
}

/// <summary>
/// Base exception class for application-specific errors
/// </summary>
public class BaseException : Exception
{
    /// <summary>
    /// Additional exception data
    /// </summary>
    public object? Exception { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="exception">Additional exception data</param>
    /// <param name="message">Error message</param>
    public BaseException(object? exception = null, string? message = null)
        : base(message)
    {
        Exception = exception;
    }

    /// <summary>
    /// Constructor with inner exception
    /// </summary>
    /// <param name="exception">Additional exception data</param>
    /// <param name="message">Error message</param>
    /// <param name="innerException">Inner exception</param>
    public BaseException(object? exception, string? message, Exception? innerException)
        : base(message, innerException)
    {
        Exception = exception;
    }
}