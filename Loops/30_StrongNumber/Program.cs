using System;

class Program
{
    static void Main()
    {
        // Input number
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        int temp = num;
        int sum = 0;

        // Calculating sum of factorial of digits
        while (temp > 0)
        {
            int digit = temp % 10;
            int fact = 1;

            for (int i = 1; i <= digit; i++)
            {
                fact *= i;
            }

            sum += fact;
            temp /= 10;
        }

        if (sum == num)
            Console.WriteLine("Strong Number");
        else
            Console.WriteLine("Not a Strong Number");
    }
}
