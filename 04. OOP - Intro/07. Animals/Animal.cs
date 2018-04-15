using System;
using System.Collections.Generic;
using System.Text;


class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("Invalid input");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;

        set
        {
            if (value == 0)
            {
                throw new ArgumentNullException("Invalid input");
            }
            this.age = value;
        }

    }

    public string Gender
    {
        get => this.gender;

        set
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentNullException("Invalid input");
            }
            this.gender = value;
        }
    }

    public virtual void ProduceSound()
    {
        if (this.gender.ToLower() == "kitten")
        {
            Console.WriteLine("Cat");
            Console.WriteLine($"{this.name}  {this.age} {this.gender}");
            Console.WriteLine("Meow");
        }
        else if(this.gender.ToLower() == "tomcat")
        {
            Console.WriteLine("Cat");
            Console.WriteLine($"{this.name}  {this.age} {this.gender}");
            Console.WriteLine("MEOW");
        }
    }
}

