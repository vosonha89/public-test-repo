using System.ComponentModel;

namespace Test003.Core.Domain.Common.Constant;

/// <summary>
/// Filter condition for query operations
/// </summary>
public enum FilterCondition
{
    /// <summary>
    /// Like operator (contains)
    /// </summary>
    [Description("~")] Like,

    /// <summary>
    /// Equal operator
    /// </summary>
    [Description("=")] Equal,

    /// <summary>
    /// Not equal operator
    /// </summary>
    [Description("!=")] NotEqual,

    /// <summary>
    /// Greater than operator
    /// </summary>
    [Description(">")] GreaterThan,

    /// <summary>
    /// Greater than or equal operator
    /// </summary>
    [Description(">=")] GreaterThanOrEqual,

    /// <summary>
    /// Less than operator
    /// </summary>
    [Description("<")] LessThan,

    /// <summary>
    /// Less than or equal operator
    /// </summary>
    [Description("<=")] LessThanOrEqual
}

/// <summary>
/// Extension methods for FilterCondition enum
/// </summary>
public static class FilterConditionExtensions
{
    /// <summary>
    /// Gets the string representation of the filter condition
    /// </summary>
    /// <param name="condition">The filter condition</param>
    /// <returns>String representation of the condition</returns>
    public static string ToSymbol(this FilterCondition condition)
    {
        return condition switch
        {
            FilterCondition.Like => "~",
            FilterCondition.Equal => "=",
            FilterCondition.NotEqual => "!=",
            FilterCondition.GreaterThan => ">",
            FilterCondition.GreaterThanOrEqual => ">=",
            FilterCondition.LessThan => "<",
            FilterCondition.LessThanOrEqual => "<=",
            _ => "="
        };
    }

    /// <summary>
    /// Gets a FilterCondition from its string representation
    /// </summary>
    /// <param name="symbol">The condition symbol</param>
    /// <returns>The corresponding FilterCondition or Equal if not found</returns>
    public static FilterCondition FromSymbol(string symbol)
    {
        return symbol switch
        {
            "~" => FilterCondition.Like,
            "=" => FilterCondition.Equal,
            "!=" => FilterCondition.NotEqual,
            ">" => FilterCondition.GreaterThan,
            ">=" => FilterCondition.GreaterThanOrEqual,
            "<" => FilterCondition.LessThan,
            "<=" => FilterCondition.LessThanOrEqual,
            _ => FilterCondition.Equal
        };
    }
}