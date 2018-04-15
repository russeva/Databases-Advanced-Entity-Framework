using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Raw_Data
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> dbCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(' ');
                    string model = input[0];
                    int engineSpeed = int.Parse(input[1]);
                    int enginePower = int.Parse(input[2]);
                    int cargoWeight = int.Parse(input[3]);
                    string cargoType = input[4];
                    double tire1p = double.Parse(input[5]);
                    double tire1a = double.Parse(input[6]);
                    double tire2p = double.Parse(input[7]);
                    double tire2a = double.Parse(input[8]);
                    double tire3p = double.Parse(input[9]);
                    double tire3a = double.Parse(input[10]);
                    double tire4p = double.Parse(input[11]);
                    double tire4a = double.Parse(input[12]);

                    Engine currentEngine = new Engine(engineSpeed, enginePower);
                    Cargo currentCargo = new Cargo(cargoWeight, cargoType);
                    Tire currentTires = new Tire(tire1p, tire1a, tire2p, tire2a, tire3p, tire3a, tire4p, tire4a);
                    Car currentCar = new Car(model, currentEngine, currentCargo, currentTires);

                    dbCars.Add(currentCar);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var entry in dbCars)
                {
                    bool tirePressureUnder1 = entry.Tires.PressureUnder1Percent();

                    if (entry.Cargo.Type == "fragile" && tirePressureUnder1 == true)
                    {
                        Console.WriteLine(entry.Model.ToString());
                    }

                }
            }
            else if (command == "flammable")
            {
                foreach (var entry in dbCars)
                {
                    if (entry.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(entry.Model.ToString());
                    }
                }
            }
        }

    }
}

