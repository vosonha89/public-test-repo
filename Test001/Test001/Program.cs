// This is C# code.Please see https://aka.ms/new-console-template for more information

using Test001;

PalindromeChecker checker = new PalindromeChecker();

Console.WriteLine("Enter string to check palindrome: ");
string? userInput = Console.ReadLine();

bool isPalindrome = checker.CheckPalindrome(userInput);
Console.WriteLine(isPalindrome);