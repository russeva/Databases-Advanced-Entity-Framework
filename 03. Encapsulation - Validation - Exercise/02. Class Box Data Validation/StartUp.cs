using System;
using System.Collections.Generic;


namespace _02._Class_Box_Data_Validation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var countOfParameters = 3;
            List<double> parameters = new List<double>();

            for (int i = 0; i < countOfParameters; i++)
            {
                parameters.Add(double.Parse(Console.ReadLine()));
            }

            double length = parameters[0];
            double width = parameters[1];
            double height = parameters[2];

            Box blackBox = new Box(length, width, height);
            Console.WriteLine($"Surface Area: {blackBox.GetSurfaceArea():f2} ");
            Console.WriteLine($"Lateral Surface Area: {blackBox.GetLateralSurfaceArea():f2} ");
            Console.WriteLine($"Volume: {blackBox.GetVolume():f2} ");
        }
    }
}
