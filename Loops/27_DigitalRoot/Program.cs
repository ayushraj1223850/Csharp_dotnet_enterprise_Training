using System;

class Program
{
    static void Main()
    {
        // Input number
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        // Repeat until single digit
        while (num >= 10)
        {
            int sum = 0;

            // Summing digits
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            num = sum;
        }

        Console.WriteLine("Digital Root: " + num);
    }
}
