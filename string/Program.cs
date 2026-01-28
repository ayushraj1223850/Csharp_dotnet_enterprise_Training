using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose Program:");
        Console.WriteLine("1. Word Wand");
        Console.WriteLine("2. Name Compatibility");
        Console.WriteLine("3. Password Generator");

        int choice = int.Parse(Console.ReadLine()!);

        switch (choice)
        {
            case 1:
                WordWand.Run();
                break;

            case 2:
                NameCompatibility.Run();
                break;

            case 3:
                PasswordGenerator.Run();
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}
