using System;

class Program
{
    static void Main()
    {
        int a, b, c;

        while (true)
        {
            Console.Write("Enter side a: ");
            if (int.TryParse(Console.ReadLine(), out a)) break;
        }
        while (true)
        {
            Console.Write("Enter side b: ");
            if (int.TryParse(Console.ReadLine(), out b)) break;
        }
        while (true)
        {
            Console.Write("Enter side c: ");
            if (int.TryParse(Console.ReadLine(), out c)) break;
        }

        if (a == b && b == c)
            Console.WriteLine("Equilateral Triangle");
        else if (a == b || b == c || a == c)
            Console.WriteLine("Isosceles Triangle");
        else
            Console.WriteLine("Scalene Triangle");
    }
}
