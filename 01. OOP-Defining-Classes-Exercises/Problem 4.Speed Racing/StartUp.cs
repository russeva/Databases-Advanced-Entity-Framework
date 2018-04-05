using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_4.Speed_Racing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carsDB = new List<Car>();
            List<Car> carsToBeTracked = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            string cmd;

            for (int i = 0; i < n; i++)
            {
                string[] carToBeTracked = Console.ReadLine().Split();
                Car currentCar = new Car()
                {
                    Model = carToBeTracked[0],
                    FuelAmount = double.Parse(carToBeTracked[1]),
                    FuelConsumptionPerKM = double.Parse(carToBeTracked[2]),
                    DistanceTraveled = 0
                };
                carsToBeTracked.Add(currentCar);
            }

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] carToBeDriven = cmd.Split();
                string model = carToBeDriven[1];
                double amountOfKm = double.Parse(carToBeDriven[2]);
                
                if(carsToBeTracked.Any(x => x.Model == model))
                {
                    carsToBeTracked.Find(x => x.Model == model).Drive(amountOfKm);
                }
            }

            foreach (Car car in carsToBeTracked)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
