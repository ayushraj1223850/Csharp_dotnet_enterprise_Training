using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a character: ");
        char ch = char.ToLower(Console.ReadLine()[0]);

        switch (ch)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine("Vowel");
                break;
            default:
                Console.WriteLine("Consonant");
                break;
        }
    }
}
