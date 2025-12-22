using System;

class Program
{
    static void Main()
    {
        // Number of rows
        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        // Upper part of diamond
        for (int i = 1; i <= n; i++)
        {
            for (int space = 1; space <= n - i; space++)
                Console.Write(" ");

            for (int star = 1; star <= 2 * i - 1; star++)
                Console.Write("*");

            Console.WriteLine();
        }

        // Lower part of diamond
        for (int i = n - 1; i >= 1; i--)
        {
            for (int space = 1; space <= n - i; space++)
                Console.Write(" ");

            for (int star = 1; star <= 2 * i - 1; star++)
                Console.Write("*");

            Console.WriteLine();
        }
    }
}
