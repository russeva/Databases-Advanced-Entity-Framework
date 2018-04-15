using System;
using System.Collections.Generic;
using System.Text;


class Dog : Animal
{
    public Dog(string name, int age, string gender)
        :base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Dog");
        Console.WriteLine($"{base.Name}  {base.Age} {base.Gender}");
        Console.WriteLine("Woof!");
    }
}

