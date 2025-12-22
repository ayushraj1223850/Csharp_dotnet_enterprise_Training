using System;

class Program
{
    static void Main()
    {
        // Number of rows
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        // Outer loop for rows
        for (int i = 0; i < rows; i++)
        {
            int value = 1;

            // Printing spaces
            for (int space = 0; space < rows - i; space++)
                Console.Write(" ");

            // Printing values
            for (int j = 0; j <= i; j++)
            {
                Console.Write(value + " ");
                value = value * (i - j) / (j + 1);
            }

            Console.WriteLine();
        }
    }
}
