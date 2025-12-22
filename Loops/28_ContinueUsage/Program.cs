using System;

class Program
{
    static void Main()
    {
        // Loop from 1 to 50
        for (int i = 1; i <= 50; i++)
        {
            // Skip multiples of 3
            if (i % 3 == 0)
                continue;

            Console.Write(i + " ");
        }
    }
}
