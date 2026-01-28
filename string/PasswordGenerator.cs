using System;

class PasswordGenerator
{
    public static void Run()
    {
        string username = Console.ReadLine();

        if (username.Length != 8)
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        string firstFour = username.Substring(0, 4);
        char fifth = username[4];
        string lastThree = username.Substring(5);

        foreach (char c in firstFour)
            if (!char.IsUpper(c))
            {
                Console.WriteLine(username + " is an invalid username");
                return;
            }

        int courseId;
        if (fifth != '@' || !int.TryParse(lastThree, out courseId) || courseId < 101 || courseId > 115)
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        int sum = 0;
        foreach (char c in firstFour.ToLower())
            sum += c;

        Console.WriteLine("Password: TECH_" + sum + lastThree.Substring(1));
    }
}
