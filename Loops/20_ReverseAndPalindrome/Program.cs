// Program to reverse a number and check if it's a palindrome using while loop
using System;

class Program
{
    static void Main()
    {
        // Ask the user for a number
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        // Store the original number
        int original = num;

        // Reverse the number using while loop
        int reverse = 0;
        while (num > 0)
        {
            int digit = num % 10;
            reverse = reverse * 10 + digit;
            num /= 10;
        }

        // Display the reverse
        Console.WriteLine("Reverse of " + original + " is " + reverse);

        // Check if it's a palindrome
        if (original == reverse)
        {
            Console.WriteLine(original + " is a palindrome.");
        }
        else
        {
            Console.WriteLine(original + " is not a palindrome.");
        }
    }
}
