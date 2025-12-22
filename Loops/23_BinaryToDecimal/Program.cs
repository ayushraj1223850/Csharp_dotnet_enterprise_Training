using System;

class Program
{
    static void Main()
    {
        // Taking binary input
        Console.Write("Enter binary number: ");
        string binary = Console.ReadLine();

        int decimalValue = 0;
        int power = 1;

        // Converting binary to decimal
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            int digit = binary[i] - '0';
            decimalValue += digit * power;
            power *= 2;
        }

        Console.WriteLine("Decimal value: " + decimalValue);
    }
}
