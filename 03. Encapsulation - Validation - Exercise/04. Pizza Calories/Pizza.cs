using System;
using System.Collections.Generic;
using System.Text;


class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    

    

    public string Name
    {
        get => this.name;

        private set
        {
            if (value.Length == 0)
            {
                throw new ArgumentNullException("Invalid name");
            }
            else if (value.Length >= 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public Dough Dough
    {
        get => this.dough;

        set
        {
            this.dough = value;
        }
    }

    private List<Topping> Toppings
    {
        get => this.toppings;

        set
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range[0..10]");
            }
            else
            {
                this.toppings = value;
            }
        }

    }

    public Pizza()
    { }

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();

    }

    public void AddTopping(Topping currentTopping )
    {
        this.Toppings.Add(currentTopping);
    }

    public string GetTotalCalories()
    {
        double sum = 0;
        for (int i = 0; i < this.Toppings.Count; i++)
        {
            double currentToppingCal = this.Toppings[i].CalculateCaloriesOfTopping();
            sum += currentToppingCal;
        }
        string message = $"{this.Name} - {sum:f2} Calories.";
        return message;
    }

}

