using System;

class NameCompatibility
{
    // Method to validate name (only alphabets and space)
    static bool IsValid(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && c != ' ')
                return false;
        }
        return true;
    }

    // Method to check subsequence logic
    static bool IsSubsequence(string small, string large)
    {
        int i = 0, j = 0;

        // Traverse both strings
        while (i < small.Length && j < large.Length)
        {
            if (small[i] == large[j])
                i++;
            j++;
        }

        // If all characters of small are found in order
        return i == small.Length;
    }

    public static void Run()
    {
        // Read names from user
        string name1 = Console.ReadLine()!;
        string name2 = Console.ReadLine()!;

        bool valid1 = IsValid(name1);
        bool valid2 = IsValid(name2);

        // Validation conditions
        if (!valid1 && !valid2)
        {
            Console.WriteLine("Both " + name1 + " and " + name2 + " are invalid names");
            return;
        }
        if (!valid1)
        {
            Console.WriteLine(name1 + " is an invalid name");
            return;
        }
        if (!valid2)
        {
            Console.WriteLine(name2 + " is an invalid name");
            return;
        }

        // Remove spaces before comparison
        string n1 = name1.Replace(" ", "");
        string n2 = name2.Replace(" ", "");

        // Check made-for-each-other condition
        if (n1 == n2 || IsSubsequence(n1, n2) || IsSubsequence(n2, n1))
        {
            Console.WriteLine(name1 + " and " + name2 + " are made for each other");

            // Compatibility value = absolute length difference
            int compatibility = Math.Abs(n1.Length - n2.Length);
            Console.WriteLine("Compatibility Value is " + compatibility);
        }
        else
        {
            Console.WriteLine(name1 + " and " + name2 + " are not made for each other");
        }
    }
}
