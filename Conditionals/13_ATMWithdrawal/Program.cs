using System;

class Program
{
    static void Main()
    {
        try
        {
            // Ask if card is inserted
            Console.Write("Insert card (yes/no): ");
            string card = Console.ReadLine().ToLower();

            if (card == "yes")
            {
                // Ask for PIN
                Console.Write("Enter PIN: ");
                int pin = int.Parse(Console.ReadLine());

                if (pin == 1234) // Sample valid PIN
                {
                    int balance = 5000;

                    // Ask withdrawal amount
                    Console.Write("Enter withdrawal amount: ");
                    int amount = int.Parse(Console.ReadLine());

                    if (amount <= balance)
                        Console.WriteLine("Transaction Successful");
                    else
                        Console.WriteLine("Insufficient Balance");
                }
                else
                {
                    Console.WriteLine("Invalid PIN");
                }
            }
            else
            {
                Console.WriteLine("Card not inserted");
            }
        }
        catch
        {
            // Handle invalid input or unexpected errors
            Console.WriteLine("Error occurred! Please try again.");
        }
    }
}
