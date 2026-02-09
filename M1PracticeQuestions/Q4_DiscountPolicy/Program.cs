using System;

abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double amount);
}

class FestivalDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 5000)
            return amount * 0.90;   // 10% off
        else
            return amount * 0.95;   // 5% off
    }
}

class MemberDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 2000)
            return amount - 300;
        else
            return amount;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter purchase amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Choose policy (Festival/Member): ");
        string choice = Console.ReadLine();

        DiscountPolicy policy;

        if (choice == "Festival")
            policy = new FestivalDiscount();
        else
            policy = new MemberDiscount();

        double finalAmount = policy.GetFinalAmount(amount);

        Console.WriteLine("Final Payable Amount: " + finalAmount);
    }
}
