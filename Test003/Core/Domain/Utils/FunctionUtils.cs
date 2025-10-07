using System.Text;

namespace Test003.Core.Domain.Utils;

/// <summary>
/// Provides utility functions for common operations
/// </summary>
public static class FunctionUtils
{
    /// <summary>
    /// Converts a string to its Base64 representation
    /// </summary>
    /// <param name="plainText">The string to convert</param>
    /// <returns>Base64 encoded string</returns>
    public static string StringToBase64(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
        {
            return string.Empty;
        }

        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// Converts a Base64 encoded string back to its original string representation
    /// </summary>
    /// <param name="base64Text">The Base64 encoded string to convert</param>
    /// <returns>Decoded string</returns>
    /// <exception cref="FormatException">Thrown when the input is not a valid Base64 string</exception>
    public static string Base64ToString(string base64Text)
    {
        if (string.IsNullOrEmpty(base64Text))
        {
            return string.Empty;
        }

        try
        {
            var base64Bytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(base64Bytes);
        }
        catch (FormatException)
        {
            throw new FormatException("The input is not a valid Base64 string.");
        }
    }
}