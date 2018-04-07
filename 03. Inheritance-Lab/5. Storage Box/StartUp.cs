using System;

namespace _5._Storage_Box
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> blackBox = new Box<int>();

            for (int i = 0; i < 11; i++)
            {
                blackBox.Add(i);
            }

            Console.WriteLine(blackBox);
        }
    }
}
