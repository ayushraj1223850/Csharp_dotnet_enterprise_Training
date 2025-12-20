using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read year input
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            // Leap year condition
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                Console.WriteLine("Leap Year");
            else
                Console.WriteLine("Not a Leap Year");
        }
        catch
        {
            // Handle invalid input
            Console.WriteLine("Invalid input! Please enter a valid year.");
        }
    }
}
