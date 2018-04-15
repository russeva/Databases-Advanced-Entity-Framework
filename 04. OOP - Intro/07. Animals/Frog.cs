using System;
using System.Collections.Generic;
using System.Text;


class Frog : Animal
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {

    }

    public override void ProduceSound()
    {
        Console.WriteLine("Frog");
        Console.WriteLine($"{base.Name}  {base.Age} {base.Gender}");
        Console.WriteLine("Ribbit");
    }
}


