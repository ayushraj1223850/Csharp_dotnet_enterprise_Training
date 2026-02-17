using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Enter employment type: ");
            string employmentType = Console.ReadLine()!;

            Console.Write("Enter monthly income: ");
            double income = double.Parse(Console.ReadLine()!);

            Console.Write("Enter existing credit dues: ");
            double dues = double.Parse(Console.ReadLine()!);

            Console.Write("Enter credit score: ");
            int creditScore = int.Parse(Console.ReadLine()!);

            Console.Write("Enter number of loan defaults: ");
            int defaults = int.Parse(Console.ReadLine()!);

            // VALIDATION
            CreditRiskProcessor.ValidateCustomerDetails(
                age, employmentType, income, dues, creditScore, defaults);

            // CALCULATION
            double limit = CreditRiskProcessor.CalculateCreditLimit(
                income, dues, creditScore, defaults);

            Console.WriteLine("\nCustomer Name: " + name);
            Console.WriteLine("Approved Credit Limit: ₹" + (int)limit);
        }
        catch (InvalidCreditDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input format");
        }
    }
}
