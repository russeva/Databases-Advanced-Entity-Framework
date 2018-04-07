using System;
using System.Collections.Generic;
using System.Text;


class Book
{
    private string title;
    private string author;
    private double price;
    

    public Book(string title, string author, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get => this.title;
        set
        {
            if(value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get => this.author;

        set
        {
            string[] bothNames = value.Split();
            if(Char.IsDigit(bothNames[1],0))
            {
                throw  new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public double Price
    {
        get => this.price;

        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Price not valid");
            }
            this.price = value;
        }

    }

    public override string ToString()
    {
        return $"Title: {this.title} {Environment.NewLine}" +
            $"Author: {this.author} {Environment.NewLine}" +
            $"Price: {this.price}";
    }
}

