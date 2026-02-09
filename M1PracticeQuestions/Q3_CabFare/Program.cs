using System;

class Cab
{
    public virtual double CalculateFare(int km)
    {
        return 0;
    }
}

class Mini : Cab
{
    public override double CalculateFare(int km)
    {
        return km * 12;
    }
}

class Sedan : Cab
{
    public override double CalculateFare(int km)
    {
        return km * 15 + 50;
    }
}

class SUV : Cab
{
    public override double CalculateFare(int km)
    {
        return km * 18 + 100;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter cab type (Mini/Sedan/SUV): ");
        string type = Console.ReadLine();

        Console.Write("Enter kilometers: ");
        int km = Convert.ToInt32(Console.ReadLine());

        Cab cab;

        if (type == "Mini")
            cab = new Mini();
        else if (type == "Sedan")
            cab = new Sedan();
        else
            cab = new SUV();

        double fare = cab.CalculateFare(km);

        Console.WriteLine("Total Fare: " + fare);
    }
}
