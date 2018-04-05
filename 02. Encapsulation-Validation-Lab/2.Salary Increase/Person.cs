using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    private string firstname;
    private string lastname;
    private int age;
    private double salary;
    
    public Person(string firstname, string lastname, int age, double salary)
    {
        this.firstName = firstname;
        this.lastName = lastname;
        this.Age = age;
        this.Salary = salary;
    }

    public string firstName
    {
        get => this.firstname;

        set => this.firstname = value;
    }

    public string lastName
    {
        get => this.lastname;

        set => this.lastname = value;
    }


    public int Age
    {
        get => this.age;

        set => this.age = value;
    }

    public double Salary
    {
        get => this.salary;

        set => this.salary = value;
    }

    public void IncreaseSalary(double bonus)
    {
        if(this.age < 30)
        {
            this.salary += this.salary * bonus / 100;
        }
        else
        {
            this.salary += this.salary * bonus / 100;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.Salary} leva.";
    }
   
}

