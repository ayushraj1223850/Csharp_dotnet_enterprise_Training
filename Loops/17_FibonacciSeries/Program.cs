// Program to print the first N terms of the Fibonacci series
using System;

class Program
{
    static void Main()
    {
        // Ask the user for the number of terms
        Console.Write("Enter the number of terms: ");
        int n = int.Parse(Console.ReadLine());

        // Initialize the first two terms
        int a = 0, b = 1;

        // Print the series
        Console.Write("Fibonacci series: ");
        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");
            int next = a + b;
            a = b;
            b = next;
        }
        Console.WriteLine();
    }
}
