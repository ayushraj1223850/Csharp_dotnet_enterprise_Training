using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        string input = Console.ReadLine();

        try
        {
            // Validate numeric input
            if (!int.TryParse(input, out int amount))
            {
                throw new FormatException("Please enter a valid numeric amount.");
            }

            // Amount must be greater than zero
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // Amount should not exceed balance
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            // Deduct amount
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Remaining balance: " + balance);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction attempt completed.");
        }
    }
}
