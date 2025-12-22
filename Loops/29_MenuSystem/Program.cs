using System;

class Program
{
    static void Main()
    {
        int choice;

        // Menu keeps running until exit
        do
        {
            Console.WriteLine("\n1. Say Hello");
            Console.WriteLine("2. Show Date");
            Console.WriteLine("3. Exit");

            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello User!");
                    break;

                case 2:
                    Console.WriteLine(DateTime.Now);
                    break;

                case 3:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        } while (choice != 3);
    }
}
