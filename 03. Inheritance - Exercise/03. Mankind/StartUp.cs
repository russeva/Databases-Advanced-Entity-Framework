using System;

namespace _03._Mankind
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    if(i == 0)
                    {
                        string firstName = input[0];
                        string lastName = input[1];
                        double facNumb = double.Parse(input[2]);

                        Student currentStudent = new Student(firstName, lastName, facNumb);
                        Console.WriteLine(currentStudent.ToString());
                    }
                    else
                    {
                        string firstName = input[0];
                        string lastName = input[1];
                        double salary = double.Parse(input[2]);
                        double hoursPerDay = double.Parse(input[3]);

                        Worker currentWorker = new Worker(firstName, lastName, salary, hoursPerDay);
                        Console.WriteLine(currentWorker.ToString());
                    }
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
