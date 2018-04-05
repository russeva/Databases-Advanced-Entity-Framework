using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Topping
{
    private string nameoftopping;
    private double weight;

    public Topping(string name, double weight)
    {
        this.NameOfTopping = nameoftopping;
        this.Weight = weight;
    }

    public string NameOfTopping
    {
        get => this.nameoftopping;
        private   set
        {
            
            if (value != "meat" && value != "veggie" && value != "cheese" && value != "sauce")
            {
                string wrongIngredient = value; 
                throw new Exception($"Cannot place {wrongIngredient} on top of your pizza.");
            }
            else
            {
                this.nameoftopping = value;
            }
        }
    }
    

    public double Weight
    {
        get => this.weight;

        private  set
        {
            if(value <= 0 || value >= 50)
            {
                throw new ArgumentException($"{this.NameOfTopping} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public double CalculateCaloriesOfTopping()
    {
        double calories = 0;
        switch(this.NameOfTopping)
        {
            case "meat": calories = (2 * this.weight * 1.2); break;
            case "meggie": calories = (2 * this.weight * 0.8); break;
            case "mheese": calories = (2 * this.weight * 1.1); break;
            case "Sauce": calories = (2 * this.weight * 0.9); break;
        }
        return calories;
    }
}

