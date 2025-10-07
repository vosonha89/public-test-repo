using System.Text.Json;

namespace Test003.Core.Domain.Object;

/// <summary>
/// Dynamic source object that can hold arbitrary properties
/// </summary>
public abstract class SourceObject
{
    /// <summary>
    /// Dictionary to hold dynamic properties
    /// </summary>
    private readonly Dictionary<string, object?> _properties = new();

    /// <summary>
    /// Indexer to access properties dynamically
    /// </summary>
    /// <param name="key">Property name</param>
    /// <returns>Property value</returns>
    public object? this[string key]
    {
        get => _properties.GetValueOrDefault(key);
        set => _properties[key] = value;
    }

    /// <summary>
    /// Checks if the object contains a property with the specified name
    /// </summary>
    /// <param name="key">Property name</param>
    /// <returns>True if the property exists</returns>
    public bool ContainsKey(string key)
    {
        return _properties.ContainsKey(key);   
    }

    /// <summary>
    /// Gets all property names
    /// </summary>
    /// <returns>Array of property names</returns>
    public string[] PropertyNames()
    {
        return _properties.Keys.ToArray();  
    }
}

/// <summary>
/// Generic object type that supports mapping from a source object
/// All properties need to have values assigned to use dynamic mapping
/// </summary>
/// <typeparam name="T">Type of source object</typeparam>
public abstract class GenericObject<T> where T : SourceObject
{
    /// <summary>
    /// Dictionary to hold dynamic properties
    /// </summary>
    private readonly Dictionary<string, object?> _properties = new();

    /// <summary>
    /// Indexer to access properties dynamically
    /// </summary>
    /// <param name="key">Property name</param>
    /// <returns>Property value</returns>
    public object? this[string key]
    {
        get => _properties.GetValueOrDefault(key);
        set => _properties[key] = value;
    }

    /// <summary>
    /// Maps properties from the source object to this object
    /// </summary>
    /// <param name="source">Source object to map from</param>
    public virtual void Map(T source)
    {
        // Get all properties of the current object
        var properties = GetType().GetProperties();

        foreach (var property in properties)
        {
            // Skip properties that are not accessible
            if (!property.CanWrite)
                continue;

            var key = property.Name;

            // Check if the source object has the property
            if (source.ContainsKey(key))
            {
                var value = source[key];

                // Deep copy the value using JSON serialization/deserialization
                if (value is not null)
                {
                    var json = JsonSerializer.Serialize(value);
                    var typedValue = JsonSerializer.Deserialize(json, property.PropertyType);
                    property.SetValue(this, typedValue);

                    // Also store in property dictionary for dynamic access
                    _properties[key] = typedValue;
                }
            }
        }
    }
}