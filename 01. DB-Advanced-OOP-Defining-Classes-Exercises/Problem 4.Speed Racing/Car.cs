using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKM { get; set; }
    public double DistanceTraveled { get; set; }

    public void Drive(double amountOfKm)
    {
        if(amountOfKm * this.FuelConsumptionPerKM <= this.FuelAmount)
        {
            this.FuelAmount -= amountOfKm * this.FuelConsumptionPerKM;
            this.DistanceTraveled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

