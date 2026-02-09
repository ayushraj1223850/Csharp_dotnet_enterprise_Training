using System;

class Employee
{
    public int Id;
    public string Name;
    public string Email;
    public double Salary;

    public Employee(int id, string name, string email, double salary)
    {
        Id = id;
        Name = name;

        if (salary <= 0)
            Salary = 30000;
        else
            Salary = salary;

        if (email.Contains("@"))
            Email = email;
        else
            Email = "unknown@company.com";
    }

    public void Display()
    {
        Console.WriteLine(Id + " " + Name + " " + Email + " " + Salary);
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new Employee(1, "Ayush", "ayush@gmail.com", 50000);
        Employee e2 = new Employee(2, "Ravi", "ravimail.com", 45000);
        Employee e3 = new Employee(3, "Neha", "neha@gmail.com", -1000);

        e1.Display();
        e2.Display();
        e3.Display();
    }
}
