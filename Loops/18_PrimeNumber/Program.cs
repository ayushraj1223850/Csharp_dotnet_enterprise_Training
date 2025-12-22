// Program to check if a number is prime using for loop and break
using System;

class Program
{
    static void Main()
    {
        // Ask the user for a number
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        // Assume it's prime initially
        bool isPrime = true;

        // Check for prime
        if (num <= 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break; // Exit the loop if not prime
                }
            }
        }

        // Display the result
        if (isPrime)
        {
            Console.WriteLine(num + " is a prime number.");
        }
        else
        {
            Console.WriteLine(num + " is not a prime number.");
        }
    }
}
