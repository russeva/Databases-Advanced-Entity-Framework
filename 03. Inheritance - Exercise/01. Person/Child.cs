﻿using System;
using System.Collections.Generic;
using System.Text;


class Child : Person
{
    

    public Child(string name,int age)
        :base(name, age)
    {
        this.Age = age;
    }

    public override int Age
    {
        get => base.Age;

        set 
        {
            if(value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }

    

}

