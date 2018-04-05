using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    private string name;
    private double money;
    private List<Product> bag;

    public string Name
    {
        get => this.name;
        set
        {
            if (value == string.Empty)
            {
                throw new Exception("Name cannot be empty");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public double Money
    {
        get => this.money;

        private set
          {
            if (value < 0)
            {
                throw new Exception("Money cannot be negative");
            }
            else
            {
                this.money = value;
            }
        }
    }

    public List<Product> Bag
    {
        get => this.bag;

        set => this.bag = value;
    }
    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }
    

    public void BuyProduct(Product product)
    {
        if(this.Money < product.Price)
        {
            Console.WriteLine($"{this.Name } cannot affoird { product.Name}");
        }
        
        else
        {
            bag.Add(product);
            this.Money -= product.Price;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        
    }


}

