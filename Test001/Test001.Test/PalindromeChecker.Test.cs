namespace Test001.Test;

[TestClass]
public class PalindromeCheckerTest
{
    private PalindromeChecker _palindromeChecker;

    [TestInitialize]
    public void Setup()
    {
        _palindromeChecker = new PalindromeChecker();
    }

    #region False cases

    [TestMethod]
    public void CheckPalindrome_EmptyString_ReturnsFalse()
    {
        string input = "";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsFalse(result, "Expected empty string to return false.");
    }

    [TestMethod]
    public void CheckPalindrome_NullString_ReturnsFalse()
    {
        string input = null;
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsFalse(result, "Expected null string to return false.");
    }

    [TestMethod]
    public void CheckPalindrome_NonSimplePalindrome_ReturnsFalse()
    {
        string input = "hello";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsFalse(result, "Expected 'hello' to not be a palindrome.");
    }

    [TestMethod]
    public void CheckPalindrome_NonMixPalindrome_ReturnsFalse()
    {
        string input = "Race a car";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsFalse(result, "Expected 'Race a car' to not be a palindrome.");
    }

    #endregion

    #region True cases

    [TestMethod]
    public void CheckPalindrome_ValidPalindrome_ReturnsTrue()
    {
        string input = "madam";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsTrue(result, "Expected 'madam' to be a palindrome.");
    }

    [TestMethod]
    public void CheckPalindrome_ValidMixedAlphanumericPalindrome_ReturnsTrue()
    {
        string input = "A1B2C2B1A";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsTrue(result, "Expected 'A1B2C2B1A' to be a palindrome.");
    }

    [TestMethod]
    public void CheckPalindrome_SingleCharacter_ReturnsTrue()
    {
        string input = "a";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsTrue(result, "Expected single character to be a palindrome.");
    }

    [TestMethod]
    public void CheckPalindrome_EvenLengthPalindrome_ReturnsTrue()
    {
        string input = "deed";
        bool result = _palindromeChecker.CheckPalindrome(input);
        Assert.IsTrue(result, "Expected 'deed' to be a palindrome.");
    }

    #endregion
}