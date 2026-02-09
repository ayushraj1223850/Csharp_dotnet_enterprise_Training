using System;

class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance)
    {
        if (initialBalance > 0)
            balance = initialBalance;
        else
            balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
            balance -= amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
{
    BankAccount account = new BankAccount(1000);

    for (int i = 0; i < 4; i++)
    {
        Console.Write("Enter D for Deposit or W for Withdraw: ");
        string type = Console.ReadLine().ToUpper();   // FIX HERE

        Console.Write("Enter amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        if (type == "D")
            account.Deposit(amount);
        else if (type == "W")
            account.Withdraw(amount);
        else
            Console.WriteLine("Invalid transaction type");
    }

    Console.WriteLine("Final Balance: " + account.GetBalance());
}
}
