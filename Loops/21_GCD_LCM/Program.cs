using System;

class Program
{
    static void Main()
    {
        // Input from user
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int x = a;
        int y = b;

        // Finding GCD using Euclidean algorithm
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }

        int gcd = x;
        int lcm = (a * b) / gcd;

        // Printing results
        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }
}
