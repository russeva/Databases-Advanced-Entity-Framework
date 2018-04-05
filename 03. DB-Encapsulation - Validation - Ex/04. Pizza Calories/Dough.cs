using System;
using System.Collections.Generic;
using System.Text;



class Dough
{
    private string flourtype;
    private string bakingtechnique;
    private double weight;

    public Dough(string flourtype, string bakingtechnique, double weight)
    {
        this.FlourType = flourtype;
        this.BakingTechnique = bakingtechnique;
        this.weight = weight;
    }

    private string FlourType
    {
        get => this.flourtype;

        set
        {
            if (value == "white" || value == "wholegrain")
            {
                
                this.flourtype = value;
            }
            
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }

    private string BakingTechnique
    {
        get => this.bakingtechnique;
       
        set
        {
            this.bakingtechnique = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        
        set
        {
            if(value < 0 || value > 200)
            {
                throw new Exception("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public double CalculateCaloriesOfDough()
    {

        double calories = 0.0;

        switch (this.flourtype)
        {

            case "white":
                switch (this.bakingtechnique)
                {
                    case "crispy": calories = (2.0 * this.weight * 1.5 * 0.9); break;
                    case "chewy": calories = (2.0 * this.weight * 1.5 * 1.1); break;
                    case "homemade": calories = (2.0 * this.weight * 1.5 * 1.0); break;
                }
                break;

            case "wholegrain":
                switch (this.bakingtechnique)
                {
                    case "crispy": calories = (2.0 * this.weight * 1.0 * 0.9); break;
                    case "chewy": calories = (2.0 * this.weight * 1.0 * 1.1); break;
                    case "homemade": calories = (2.0 * this.weight * 1.0 * 1.0); break;
                }; break;


        }

        return calories;
    }

   

  
}

