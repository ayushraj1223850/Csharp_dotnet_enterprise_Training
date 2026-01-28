using System;

class WordWand
{
    public static void Run()
    {
        // Read the sentence from the user
        string sentence = Console.ReadLine()!;

        // Validation: check for only alphabets and space
        foreach (char c in sentence)
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                Console.WriteLine("Invalid Sentence");
                return; // Stop execution if invalid
            }
        }

        // Split sentence into words
        string[] words = sentence.Split(' ');
        int count = words.Length;

        // Display word count
        Console.WriteLine("Word Count: " + count);

        // If number of words is even → reverse word order
        if (count % 2 == 0)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                Console.Write(words[i] + " ");
            }
        }
        // If number of words is odd → reverse letters of each word
        else
        {
            foreach (string word in words)
            {
                string rev = "";

                // Reverse each word character by character
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    rev += word[i];
                }

                Console.Write(rev + " ");
            }
        }
    }
}
