// Program to check if a number is an Armstrong number
using System;

class Program
{
    static void Main()
    {
        // Ask the user for a number
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        // Find the number of digits
        int temp = num;
        int digits = 0;
        while (temp > 0)
        {
            digits++;
            temp /= 10;
        }

        // Calculate the sum of digits raised to the power of digits
        temp = num;
        int sum = 0;
        while (temp > 0)
        {
            int digit = temp % 10;
            int power = 1;
            for (int i = 0; i < digits; i++)
            {
                power *= digit;
            }
            sum += power;
            temp /= 10;
        }

        // Check if it's Armstrong
        if (sum == num)
        {
            Console.WriteLine(num + " is an Armstrong number.");
        }
        else
        {
            Console.WriteLine(num + " is not an Armstrong number.");
        }
    }
}
