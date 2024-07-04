using System;
using System.Collections.Generic;

public delegate bool Promotable(Employee E);

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public int Experience { get; set; }

    // Removed static keyword from Promotion method and corrected parameter type
    public void Promotion(List<Employee> EmployeeList, Promotable P)
    {
        foreach (Employee emp in EmployeeList)
        {
            if (P(emp)) // Use the delegate to check if the employee is promotable
            {
                Console.WriteLine("{0} Promoted", emp.Name);
            }
        }
    }
}

public class Ali
{
    public static void Main()
    {
        List<Employee> empList = new List<Employee>();
        empList.Add(new Employee() { ID = 1, Name = "Mary Luisse", Salary = 5000, Experience = 5 });
        empList.Add(new Employee() { ID = 2, Name = "John Lorusso", Salary = 4000, Experience = 4 });
        empList.Add(new Employee() { ID = 3, Name = "Ibrahim Arabaki", Salary = 6000, Experience = 6 });
        empList.Add(new Employee() { ID = 4, Name = "Spendthrift", Salary = 3000, Experience = 3 });

        Promotable P = new Promotable(Promote);

        Employee emp = new Employee();
        emp.Promotion(empList, P);
    }

    public static bool Promote(Employee Emp)
    {
        if (Emp.Experience >= 5 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}