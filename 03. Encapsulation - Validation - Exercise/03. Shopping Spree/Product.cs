using System;
using System.Collections.Generic;
using System.Text;


class Product
{
    private string name;
    private double price;

    public string Name
    {
        get => this.name;

        private set
        {
            if (value.Length == 0)
            {
                throw new ArgumentException( "Product must have name");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public double Price
    {
        get => this.price;

        private set
        {
            if (value <= 0)
            {
               throw new ArgumentException("Price cannot be negative or zero");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
}

