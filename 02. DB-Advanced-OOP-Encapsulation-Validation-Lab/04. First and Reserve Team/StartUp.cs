using System;

namespace _04._First_and_Reserve_Team
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Team newTeam = new Team("Test");
            Person person1 = new Person("Peter", "Kruder",35, 3400);
            Person person2 = new Person("Stefan", "Dorfmeister", 23, 1650);

            newTeam.AddPlayer(person1);
            newTeam.AddPlayer(person2);

            Console.WriteLine("Main team: ");
            Console.WriteLine(newTeam.FirstTeam);

            Console.WriteLine("ReserveTeam: ");
            Console.WriteLine(newTeam.ReserveTeam);
        }
    }
}
