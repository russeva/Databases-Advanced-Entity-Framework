using System;
using System.Collections.Generic;
using System.Text;


class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public Employee(string name, double salary, string position, string department, string email)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
    }

    public Employee(string name, double salary, string position, string department, string email, int age)
        : this(name, salary, position, department, email)
    {
        this.Age = age;
    }
}
