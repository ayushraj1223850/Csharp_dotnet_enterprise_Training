using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read day, month, year
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            // Check leap year
            bool isLeap = (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0));

            // Days in each month
            int[] daysInMonth = { 31, isLeap ? 29 : 28, 31, 30, 31, 30,
                                  31, 31, 30, 31, 30, 31 };

            // Validate date
            if (month >= 1 && month <= 12 &&
                day >= 1 && day <= daysInMonth[month - 1])
                Console.WriteLine("Valid Date");
            else
                Console.WriteLine("Invalid Date");
        }
        catch
        {
            // Handle invalid numeric input
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
    }
}
