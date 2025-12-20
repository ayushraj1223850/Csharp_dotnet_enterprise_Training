using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read first number
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            // Read second number
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            // Read third number
            Console.Write("Enter third number: ");
            int c = int.Parse(Console.ReadLine());

            // Nested if to find largest number
            if (a > b)
            {
                if (a > c)
                    Console.WriteLine("Largest number is: " + a);
                else
                    Console.WriteLine("Largest number is: " + c);
            }
            else
            {
                if (b > c)
                    Console.WriteLine("Largest number is: " + b);
                else
                    Console.WriteLine("Largest number is: " + c);
            }
        }
        catch
        {
            // Handle invalid input
            Console.WriteLine("Invalid input! Please enter only integers.");
        }
    }
}
