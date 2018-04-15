using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _01._Oldest_Family_Member
{
    class StartUp
    {
        static void Main(string[] args)
        {
            

            int n = int.Parse(Console.ReadLine());
            Family currentFamily = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newMember = new Person();
                try
                {
                    newMember.Age = age;
                    newMember.Name = name;
                    currentFamily.AddMember(newMember);
                    
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
            }
            currentFamily.GetOldestMember();

          
        }
    }
}
