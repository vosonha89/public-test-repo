using System.Net;
using Test003.Core.Domain.Common.Base;

namespace Test003.Core.Domain.Common.Constant;

/// <summary>
/// Global error definitions and helper methods
/// </summary>
public static class GlobalError
{
    /// <summary>
    /// Internal server error
    /// </summary>
    public static readonly ErrorMessage InternalServerError = new()
    {
        Code = (int)HttpStatusCode.InternalServerError,
        Msg = "InternalServerError"
    };

    /// <summary>
    /// Bad request error
    /// </summary>
    public static readonly ErrorMessage BadRequestError = new()
    {
        Code = (int)HttpStatusCode.BadRequest,
        Msg = "BadRequestError"
    };

    /// <summary>
    /// Unauthorized error
    /// </summary>
    public static readonly ErrorMessage UnauthorizedError = new()
    {
        Code = (int)HttpStatusCode.Unauthorized,
        Msg = "UnauthorizedError"
    };

    /// <summary>
    /// Forbidden error
    /// </summary>
    public static readonly ErrorMessage ForbiddenError = new()
    {
        Code = (int)HttpStatusCode.Forbidden,
        Msg = "ForbiddenError"
    };

    /// <summary>
    /// Not found error
    /// </summary>
    public static readonly ErrorMessage NotFoundError = new()
    {
        Code = (int)HttpStatusCode.NotFound,
        Msg = "NotFoundError"
    };

    /// <summary>
    /// Creates a required field error message
    /// </summary>
    /// <param name="fieldName">Name of the required field</param>
    /// <returns>Error message for the required field</returns>
    public static ErrorMessage RequiredError(string fieldName)
    {
        return new ErrorMessage
        {
            Code = (int)HttpStatusCode.BadRequest * 10 + 1,
            Msg = $"{fieldName.Trim()} is required."
        };
    }

    /// <summary>
    /// Creates a type error message for an invalid field type
    /// </summary>
    /// <param name="fieldName">Name of the field with an incorrect type</param>
    /// <param name="fieldType">Expected type of the field</param>
    /// <returns>Error message for type error</returns>
    public static ErrorMessage TypeError(string fieldName, string fieldType)
    {
        return new ErrorMessage
        {
            Code = (int)HttpStatusCode.BadRequest * 10 + 2,
            Msg = $"{fieldName.Trim()} is not valid {fieldType} type."
        };
    }
}