using System;
using System.Linq;

namespace _04._Pizza_Calories
{
    

    class StartUp
    {
     

        static void Main(string[] args)
        {
            string input;
            Pizza myPizza = new Pizza();

            while((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputArgs = input.Split().ToArray();
                string ingredientType = inputArgs[0];

                if (ingredientType == "dough")
                {
                    string type = inputArgs[1];
                    string bakingTechnique = inputArgs[2];
                    double weight = double.Parse(inputArgs[3]);

                    Dough currentDough = new Dough(type, bakingTechnique, weight);
                    Console.WriteLine(currentDough.CalculateCaloriesOfDough());
                }
                if(ingredientType == "topping")
                {
                    string typeOfTopping = inputArgs[1];
                    double weight = double.Parse(inputArgs[2]);

                    Topping currentTopping = new Topping(typeOfTopping, weight);
                    myPizza.AddTopping(currentTopping);

                    Console.WriteLine(currentTopping.CalculateCaloriesOfTopping());
                }

                
                   

               
            }
            
        }
    }
}
