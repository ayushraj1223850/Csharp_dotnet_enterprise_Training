using System;

class Program
{
    static void Main()
    {
        try
        {
            // Read Player 1 choice
            Console.Write("Player 1 (rock/paper/scissors): ");
            string p1 = Console.ReadLine().ToLower();

            // Read Player 2 choice
            Console.Write("Player 2 (rock/paper/scissors): ");
            string p2 = Console.ReadLine().ToLower();

            // Compare choices
            if (p1 == p2)
                Console.WriteLine("Draw");
            else if ((p1 == "rock" && p2 == "scissors") ||
                     (p1 == "paper" && p2 == "rock") ||
                     (p1 == "scissors" && p2 == "paper"))
                Console.WriteLine("Player 1 Wins");
            else if ((p2 == "rock" && p1 == "scissors") ||
                     (p2 == "paper" && p1 == "rock") ||
                     (p2 == "scissors" && p1 == "paper"))
                Console.WriteLine("Player 2 Wins");
            else
                Console.WriteLine("Invalid input");
        }
        catch
        {
            // Handle unexpected runtime errors
            Console.WriteLine("Error occurred! Please try again.");
        }
    }
}
