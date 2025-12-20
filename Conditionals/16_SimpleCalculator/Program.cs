using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read first number
            Console.Write("Enter first number: ");
            double a = double.Parse(Console.ReadLine());

            // Read second number
            Console.Write("Enter second number: ");
            double b = double.Parse(Console.ReadLine());

            // Read operator
            Console.Write("Enter operator (+ - * /): ");
            char op = Console.ReadLine()[0];

            // Perform operation using switch
            switch (op)
            {
                case '+':
                    Console.WriteLine("Result: " + (a + b));
                    break;
                case '-':
                    Console.WriteLine("Result: " + (a - b));
                    break;
                case '*':
                    Console.WriteLine("Result: " + (a * b));
                    break;
                case '/':
                    if (b != 0)
                        Console.WriteLine("Result: " + (a / b));
                    else
                        Console.WriteLine("Cannot divide by zero");
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }
        }
        catch
        {
            // Handle invalid input
            Console.WriteLine("Invalid input! Please enter correct values.");
        }
    }
}
