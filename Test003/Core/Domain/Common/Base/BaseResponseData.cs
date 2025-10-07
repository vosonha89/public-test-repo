using System.Net;

namespace Test003.Core.Domain.Common.Base;

/// <summary>
/// Base response data class for all API responses
/// </summary>
/// <typeparam name="T">Type of data being returned</typeparam>
public abstract class BaseResponseData<T>
{
    /// <summary>
    /// Server date and time when the response was generated
    /// </summary>
    public DateTime ServerDateTime { get; set; }

    /// <summary>
    /// HTTP status code
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Response message
    /// </summary>
    public string Msg { get; set; }

    /// <summary>
    /// Exception details if an error occurred
    /// </summary>
    public ClientError? Exception { get; set; }

    /// <summary>
    /// Response data
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Whether the request was successful
    /// </summary>
    public bool Successful { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    protected BaseResponseData()
    {
        ServerDateTime = DateTime.UtcNow;
        Status = (int)HttpStatusCode.BadRequest;
        Msg = string.Empty;
        Exception = null;
        Data = default;
        Successful = false;
    }
}

/// <summary>
/// Base search response with pagination information
/// </summary>
/// <typeparam name="T">Type of elements in the search results</typeparam>
public class BaseSearchResponse<T>
{
    /// <summary>
    /// Current page number (1-based)
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Page size
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Total number of elements across all pages
    /// </summary>
    public int TotalElements { get; set; }

    /// <summary>
    /// Total number of pages
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Elements on the current page
    /// </summary>
    public IList<T> Elements { get; set; } = new List<T>();

    /// <summary>
    /// Whether there are previous pages available
    /// </summary>
    public bool HasPrevious { get; set; }

    /// <summary>
    /// Whether there are more pages available
    /// </summary>
    public bool HasMore { get; set; }
}

/// <summary>
/// Base item response for entity data
/// </summary>
/// <typeparam name="T">Type of source object</typeparam>
public abstract class BaseItemResponse<T>
{
    /// <summary>
    /// Entity identifier
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTime Created { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Last update timestamp
    /// </summary>
    public DateTime Updated { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Maps properties from the source object to this response
    /// </summary>
    /// <param name="source">Source object to map from</param>
    public virtual void Map(T source)
    {
        // Base implementation to be overridden by derived classes
        // Object mapping will depend on implementation details
    }
}

/// <summary>
/// Base item response for admin-oriented views with additional fields
/// </summary>
/// <typeparam name="T">Type of source object</typeparam>
public abstract class BaseItemInAdminResponse<T> : BaseItemResponse<T>
{
    /// <summary>
    /// Whether the item is deleted (for soft delete)
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}

/// <summary>
/// Concrete implementation of BaseResponseData for standard API responses
/// </summary>
/// <typeparam name="T">Type of data being returned</typeparam>
public class BaseResponse<T> : BaseResponseData<T>
{
    /// <summary>
    /// Creates a new response with the specified parameters
    /// </summary>
    /// <param name="status">HTTP status code</param>
    /// <param name="data">Response data</param>
    /// <param name="successful">Whether the request was successful</param>
    /// <param name="msg">Response message</param>
    /// <param name="exception">Exception details if an error occurred</param>
    public BaseResponse(HttpStatusCode status, T? data = default, bool successful = false, string msg = "", ClientError? exception = null)
    {
        Status = (int)status;
        Msg = msg;
        Exception = exception;
        Data = data;
        Successful = successful;
    }

    /// <summary>
    /// Creates a successful OK response with the provided data
    /// </summary>
    /// <param name="data">Data to include in the response</param>
    /// <returns>A successful response with OK status</returns>
    public static BaseResponse<T> Ok(T? data = default)
    {
        return new BaseResponse<T>(HttpStatusCode.OK, data, true);
    }
}