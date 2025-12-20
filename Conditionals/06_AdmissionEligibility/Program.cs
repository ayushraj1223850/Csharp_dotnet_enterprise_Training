using System;

class Program
{
    static void Main()
    {
        int math, phys, chem;

        // Read Math marks
        while (true)
        {
            Console.Write("Enter Math marks: ");
            if (int.TryParse(Console.ReadLine(), out math)) break;
            Console.WriteLine("Invalid input. Enter a number.");
        }

        // Read Physics marks
        while (true)
        {
            Console.Write("Enter Physics marks: ");
            if (int.TryParse(Console.ReadLine(), out phys)) break;
            Console.WriteLine("Invalid input. Enter a number.");
        }

        // Read Chemistry marks
        while (true)
        {
            Console.Write("Enter Chemistry marks: ");
            if (int.TryParse(Console.ReadLine(), out chem)) break;
            Console.WriteLine("Invalid input. Enter a number.");
        }

        int total = math + phys + chem;

        // Check eligibility
        if (math >= 65 && phys >= 55 && chem >= 50 &&
            (total >= 180 || math + phys >= 140))
            Console.WriteLine("Eligible for admission");
        else
            Console.WriteLine("Not eligible for admission");
    }
}
