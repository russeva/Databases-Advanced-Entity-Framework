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
        this.FirstName = firstname;
        this.LastName = lastname;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get => this.firstname;

      private  set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }
           this.firstname = value;
        }
    }

    public string LastName
    {
        get => this.lastname;

        set
        {
            if(value.Length > 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }
            else
            {
                this.lastname = value;
            }
        }
    }


    public int Age
    {
        get => this.age;

        private  set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }
            else
            {
                this.age = value;
            }
        }
    }

    public double Salary
    {
        get => this.salary;

        private  set
        {
            if(value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460");
            }
        }
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
        return $"{this.FirstName} {this.LastName} get {this.Salary} leva.";
    }
   
}

