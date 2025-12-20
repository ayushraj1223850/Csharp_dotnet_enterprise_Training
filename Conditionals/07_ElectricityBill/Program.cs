using System;

class Program
{
    static void Main()
    {
        int units;
        double bill;

        while (true)
        {
            Console.Write("Enter units consumed: ");
            if (int.TryParse(Console.ReadLine(), out units) && units >= 0) break;
            Console.WriteLine("Invalid input.");
        }

        // Calculate bill based on slabs
        if (units < 200)
            bill = units * 1.20;
        else if (units < 400)
            bill = units * 1.50;
        else if (units < 600)
            bill = units * 1.80;
        else
            bill = units * 2.00;

        // Add surcharge if bill > 400
        if (bill > 400)
            bill += bill * 0.15;

        Console.WriteLine("Total bill amount: " + bill);
    }
}
