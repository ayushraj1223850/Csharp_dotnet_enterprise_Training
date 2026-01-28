using System;

class WordWand
{
    public static void Run()
    {
        string? sentence = Console.ReadLine();

        foreach (char c in sentence)
        {
            if (!char.IsLetter(c) && c != ' ')
            {
                Console.WriteLine("Invalid Sentence");
                return;
            }
        }

        string[] words = sentence.Split(' ');
        int count = words.Length;

        Console.WriteLine("Word Count: " + count);

        if (count % 2 == 0)
        {
            for (int i = count - 1; i >= 0; i--)
                Console.Write(words[i] + " ");
        }
        else
        {
            foreach (string word in words)
            {
                string rev = "";
                for (int i = word.Length - 1; i >= 0; i--)
                    rev += word[i];

                Console.Write(rev + " ");
            }
        }
    }
}
