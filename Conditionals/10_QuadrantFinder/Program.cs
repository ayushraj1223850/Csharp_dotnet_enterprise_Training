using System;

class Program
{
    static void Main()
    {
        int x, y;

        while (true)
        {
            Console.Write("Enter X coordinate: ");
            if (int.TryParse(Console.ReadLine(), out x)) break;
        }
        while (true)
        {
            Console.Write("Enter Y coordinate: ");
            if (int.TryParse(Console.ReadLine(), out y)) break;
        }

        if (x > 0 && y > 0)
            Console.WriteLine("1st Quadrant");
        else if (x < 0 && y > 0)
            Console.WriteLine("2nd Quadrant");
        else if (x < 0 && y < 0)
            Console.WriteLine("3rd Quadrant");
        else if (x > 0 && y < 0)
            Console.WriteLine("4th Quadrant");
        else
            Console.WriteLine("On Axis");
    }
}
