using System;
using System.Collections.Generic;
using System.Text;


class Cat : Animal
{
    public Cat(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Cat");
        Console.WriteLine($"{base.Name}  {base.Age} {base.Gender}");
        Console.WriteLine("Meow meow");
    }
}

