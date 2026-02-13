using System.Runtime.InteropServices.Marshalling;
using System.Globalization;

public class StringConversion
{
    public static void Run()
    {
        // To integer

        int.TryParse("42", out int value);
        Console.Write(value); // 42 

        // To Double

        double d = double.Parse("12.34");
        Console.WriteLine(d);

        // Split by spaces and turn each piece into integers. "1 2 3 4"
        string input = "1 2 3 4";
        int[]numbers = input.Split(' ').Select(int.Parse).ToArray();

        // Input: "9.5 8.3 7.1" – Break it apart and convert these to a list of doubles.
        string input1 = "9.5 8.3 7.1";
        List<double> l = input1.Split(' ').Select(double.Parse).ToList();

        // Input: "Fifty" – Validate that this string is not a number at all.
        string input2 = "Fifty";
        bool isNumber = int.TryParse(input2, out _);
        Console.WriteLine(isNumber);

        // Input: "15.7abc" – Extract just the numeric portion.
        string input3 = "15.7abc";


        // Input: "999999999" – Convert this large number into a long.
        long longNumber = long.Parse("999999999");

        // Input: "0xFF" – Convert this hex string into an integer.
        int hex = Convert.ToInt32("0xFF", 16);
        Console.WriteLine(hex);

        // Input: "3E+3" – Convert this scientific notation into a double.
        double sci = double.Parse("3E+3");
        Console.WriteLine(sci);

        // Input: "42.5 36.1 -12" – Handle positive and negative numbers from a string.
        string input4 = "42.5 36.1 -12";
        var nums = input4.Split(' ').Select(double.Parse).ToList();

        // Input: " 75 " – Trim spaces and convert the result to an integer.
        int n = int.Parse(" 75 ".Trim());

        // Input: "3.14.15" – Detect and report that this is not a valid number.

        bool valid = double.TryParse("3.14.15", out _);
        Console.WriteLine(valid);

        // Input: "1.000.000" – Handle formatting where dots are used as group separators.
        double num = double.Parse("1.000.000", new CultureInfo("de-DE"));
        Console.WriteLine(num);

        // Input: "1,234.56" – Convert a number formatted with commas and a decimal.
        double num1 = double.Parse("1,234.56", CultureInfo.InvariantCulture);
        Console.WriteLine(num1);

        // Input: "(123)" – Treat this as a negative number.
        string input5 = "(123)";
        int neg = int.Parse(input5.Replace("(", "-").Replace(")", ""));
        Console.WriteLine(neg);

        // Input: "12:30" – Convert time (hours and minutes) into total minutes.
        string[]time = "12:30".Split(":");
        int hours = int.Parse(time[0])*60;
        int min = int.Parse(time[1]);
        Console.WriteLine(hours+min);

        // Input: "0b1011" – Convert a binary string to an integer.
        int binary = Convert.ToInt32("1011", 2);
        Console.WriteLine(binary);



    }

}