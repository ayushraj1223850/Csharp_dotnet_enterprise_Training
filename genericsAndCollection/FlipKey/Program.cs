using System;
using System.Linq;
using System.Text;

public class FlipKey
{
    public string CleanseAndInvert(string input)
    {
        // ---------- Input Validation ----------
        if (string.IsNullOrWhiteSpace(input) || input.Length < 6)
            return string.Empty;

        // Reject input containing spaces, digits, or special characters
        if (!input.All(char.IsLetter))
            return string.Empty;

        // ---------- Transformation Pipeline ----------
        var transformedChars = input
            .ToLowerInvariant()                 // Culture-safe lowercase
            .Where(c => c % 2 != 0)              // Keep characters with odd ASCII values
            .Reverse()                           // Reverse remaining characters
            .Select((c, index) =>                // Uppercase characters at even indices
                index % 2 == 0 ? char.ToUpperInvariant(c) : c
            );

        // ---------- Build Result ----------
        return new string(transformedChars.ToArray());
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        FlipKey flipKey = new FlipKey();
        string result = flipKey.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine($"The generated key is - {result}");
        }
    }
}
