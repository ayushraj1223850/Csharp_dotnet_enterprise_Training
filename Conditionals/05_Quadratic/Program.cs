using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read coefficients
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Enter c: ");
            double c = double.Parse(Console.ReadLine());

            // Calculate discriminant
            double d = b * b - 4 * a * c;

            // Check discriminant value
            if (d > 0)
            {
                double r1 = (-b + Math.Sqrt(d)) / (2 * a);
                double r2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Two real roots: " + r1 + " and " + r2);
            }
            else if (d == 0)
            {
                double r = -b / (2 * a);
                Console.WriteLine("One real root: " + r);
            }
            else
            {
                Console.WriteLine("No real roots");
            }
        }
        catch
        {
            // Handle invalid input or math errors
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
    }
}
