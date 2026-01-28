using System;

class PasswordGenerator
{
    public static void Run()
    {
        // Read username from user
        string username = Console.ReadLine()!;

        // Check username length
        if (username.Length != 8)
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        // Extract parts of username
        string firstFour = username.Substring(0, 4);
        char fifthChar = username[4];
        string lastThree = username.Substring(5);

        // Validate first four characters (uppercase letters)
        foreach (char c in firstFour)
        {
            if (!char.IsUpper(c))
            {
                Console.WriteLine(username + " is an invalid username");
                return;
            }
        }

        // Validate '@' and course ID
        int courseId;
        if (fifthChar != '@' || !int.TryParse(lastThree, out courseId) ||
            courseId < 101 || courseId > 115)
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        // Calculate ASCII sum after converting to lowercase
        int sum = 0;
        foreach (char c in firstFour.ToLower())
        {
            sum += c;
        }

        // Generate password
        string password = "TECH_" + sum + lastThree.Substring(1);

        // Display password
        Console.WriteLine("Password: " + password);
    }
}
