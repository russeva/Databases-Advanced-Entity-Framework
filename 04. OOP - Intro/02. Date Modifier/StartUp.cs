using System;

namespace _02._Date_Modifier
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            Date_Modifier currentDiff = new Date_Modifier();

            var diff = Math.Abs((currentDiff.CalculateDays(date1, date2)));
            Console.WriteLine(diff);
        }
    }
}
