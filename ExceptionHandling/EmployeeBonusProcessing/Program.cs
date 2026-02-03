using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        // 1. Loop through salaries
        foreach (int salary in salaries)
        {
            try
            {
                // 2. Divide bonus by salary
                int result = bonus / salary;
                Console.WriteLine("Bonus per unit salary: " + result);
            }
            catch (DivideByZeroException)
            {
                // 3. Handle divide by zero
                Console.WriteLine("Error: Salary cannot be zero.");
            }
        }

        // 4. Continue processing remaining employees
        Console.WriteLine("Bonus processing completed for all employees.");
    }
}
