using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read Cost Price
            Console.Write("Enter Cost Price: ");
            double cp = double.Parse(Console.ReadLine());

            // Read Selling Price
            Console.Write("Enter Selling Price: ");
            double sp = double.Parse(Console.ReadLine());

            // Calculate profit or loss
            if (sp > cp)
            {
                double profit = ((sp - cp) / cp) * 100;
                Console.WriteLine("Profit % = " + profit);
            }
            else if (cp > sp)
            {
                double loss = ((cp - sp) / cp) * 100;
                Console.WriteLine("Loss % = " + loss);
            }
            else
            {
                Console.WriteLine("No Profit No Loss");
            }
        }
        catch
        {
            // Handle invalid numeric input
            Console.WriteLine("Invalid input! Please enter valid numbers.");
        }
    }
}
