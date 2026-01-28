using System;

class Program
{
    static void Main()
    {
        // Display menu to the user
        Console.WriteLine("Choose Program:");
        Console.WriteLine("1. Word Wand");
        Console.WriteLine("2. Name Compatibility");
        Console.WriteLine("3. Password Generator");

        // Read user choice and convert it to integer
        int choice = int.Parse(Console.ReadLine()!);

        // Call the required program based on choice
        switch (choice)
        {
            case 1:
                // Calls Word Wand logic
                WordWand.Run();
                break;

            case 2:
                // Calls Name Compatibility logic
                NameCompatibility.Run();
                break;

            case 3:
                // Calls Password Generator logic
                PasswordGenerator.Run();
                break;

            default:
                // Handles invalid menu choice
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}
