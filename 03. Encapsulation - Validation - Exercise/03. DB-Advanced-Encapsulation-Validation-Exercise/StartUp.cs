using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _03._DB_Advanced_Encapsulation_Validation_Exercise
{
    class StartUp

    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var countOfParameters = 3;
            List<double> parameters = new List<double>();

            for (int i = 0; i < countOfParameters; i++)
            {
                parameters.Add(double.Parse(Console.ReadLine()));
            }

            double length = parameters[0];
            double width = parameters[1];
            double height = parameters[2];

            Box blackBox = new Box(length,width,height);

            Console.WriteLine($"Surface Area: {blackBox.GetSurfaceArea():f2} ");
            Console.WriteLine($"Lateral Surface Area: {blackBox.GetLateralSurfaceArea():f2} ");
            Console.WriteLine($"Volume: {blackBox.GetVolume():f2} ");

        }
    }
}
