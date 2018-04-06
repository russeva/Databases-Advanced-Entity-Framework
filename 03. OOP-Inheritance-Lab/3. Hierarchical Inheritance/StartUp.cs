using System;

namespace _3.Hierarchical_Inheritance
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();

            Cat cat = new Cat();
            cat.Meow();
            cat.Eat();
        }
    }
}
