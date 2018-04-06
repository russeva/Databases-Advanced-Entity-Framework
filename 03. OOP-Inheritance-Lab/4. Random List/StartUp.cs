using System;

namespace _4._Random_List
{
    class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();

            for (int i = 0; i < 10; i++)
            {
                rndList.Add($"Daisy {i}");
            }

            rndList.RandomString();
        }
    }
}
