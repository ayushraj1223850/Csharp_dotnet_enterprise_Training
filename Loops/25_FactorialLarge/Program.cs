using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        // Input from user
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        // Using BigInteger to avoid overflow
        BigInteger fact = 1;

        // Loop to calculate factorial
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }

        Console.WriteLine("Factorial: " + fact);
    }
}
