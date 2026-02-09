using System;
using System.Collections.Generic;

interface INotifier
{
    void Send(string message);
}

class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

class WhatsAppNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("WhatsApp sent: " + message);
    }
}

class Program
{
    static void Main()
    {
        List<INotifier> notifiers = new List<INotifier>();

        notifiers.Add(new EmailNotifier());
        notifiers.Add(new SmsNotifier());
        notifiers.Add(new WhatsAppNotifier());

        Console.Write("Enter message: ");
        string msg = Console.ReadLine();

        foreach (INotifier n in notifiers)
        {
            n.Send(msg);
        }
    }
}
