namespace Test003.Core.Domain.Common.Base;

/// <summary>
/// Base type class with generic identifier
/// </summary>
/// <typeparam name="TId">The type of the identifier field</typeparam>
public class BaseType<TId>
{
    /// <summary>
    /// Unique identifier for the type
    /// </summary>
    public TId Id { get; set; } = default!;
}