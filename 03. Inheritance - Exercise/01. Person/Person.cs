using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual string Name
    {
        get => this.name;

        private set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Name too short.");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get => this.age;

        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Age must be positive.");
            }
            this.age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.name}, Age {this.age}";
    }

}

