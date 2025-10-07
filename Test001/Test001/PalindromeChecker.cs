namespace Test001;

/// <summary>
/// Palindrome Checker
/// </summary>
public class PalindromeChecker
{
    /// <summary>
    /// Check Palindrome
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool CheckPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;
        int left = 0;
        int right = input.Length - 1;
        while (left < right)
        {
            if (input[left] != input[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}