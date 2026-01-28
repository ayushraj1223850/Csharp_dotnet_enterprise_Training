using System;

class NameCompatibility
{
    static bool IsValid(string name)
    {
        foreach (char c in name)
            if (!char.IsLetter(c) && c != ' ')
                return false;

        return true;
    }

    static bool IsSubsequence(string small, string large)
    {
        int i = 0, j = 0;
        while (i < small.Length && j < large.Length)
        {
            if (small[i] == large[j])
                i++;
            j++;
        }
        return i == small.Length;
    }

    public static void Run()
    {
        string name1 = Console.ReadLine();
        string name2 = Console.ReadLine();

        bool v1 = IsValid(name1);
        bool v2 = IsValid(name2);

        if (!v1 && !v2)
        {
            Console.WriteLine("Both " + name1 + " and " + name2 + " are invalid names");
            return;
        }
        if (!v1)
        {
            Console.WriteLine(name1 + " is an invalid name");
            return;
        }
        if (!v2)
        {
            Console.WriteLine(name2 + " is an invalid name");
            return;
        }

        string n1 = name1.Replace(" ", "");
        string n2 = name2.Replace(" ", "");

        if (n1 == n2 || IsSubsequence(n1, n2) || IsSubsequence(n2, n1))
        {
            Console.WriteLine(name1 + " and " + name2 + " are made for each other");
            Console.WriteLine("Compatibility Value is " + Math.Abs(n1.Length - n2.Length));
        }
        else
        {
            Console.WriteLine(name1 + " and " + name2 + " are not made for each other");
        }
    }
}
