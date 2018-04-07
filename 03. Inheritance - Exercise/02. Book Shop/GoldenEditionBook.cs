using System;
using System.Collections.Generic;
using System.Text;

class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, double price)
        :base(title, author, price)
    {
        this.Price *= 1.3;
    }
}

