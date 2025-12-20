using System;

class Program
{
    static void Main()
    {
        try
        {
            // Ask user to enter grade
            Console.Write("Enter grade (E/V/G/A/F): ");

            // Read first character and convert to uppercase
            char grade = char.ToUpper(Console.ReadLine()[0]);

            // Switch to match grade
            switch (grade)
            {
                case 'E':
                    Console.WriteLine("Excellent");
                    break;
                case 'V':
                    Console.WriteLine("Very Good");
                    break;
                case 'G':
                    Console.WriteLine("Good");
                    break;
                case 'A':
                    Console.WriteLine("Average");
                    break;
                case 'F':
                    Console.WriteLine("Fail");
                    break;
                default:
                    Console.WriteLine("Invalid Grade");
                    break;
            }
        }
        catch
        {
            // Handle unexpected input errors
            Console.WriteLine("Error occurred! Please enter a valid grade.");
        }
    }
}
