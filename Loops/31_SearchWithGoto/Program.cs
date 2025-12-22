using System;

class Program
{
    static void Main()
    {
        int[,] arr = { {1,2,3}, {4,5,6}, {7,8,9} };
        int search = 5;

        // Searching element in 2D array
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (arr[i, j] == search)
                {
                    Console.WriteLine("Element Found");
                    goto Found; // exit all loops
                }
            }
        }

        Console.WriteLine("Element Not Found");

    Found:
        Console.WriteLine("Search Completed");
    }
}
