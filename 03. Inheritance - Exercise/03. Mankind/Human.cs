using System;
using System.Collections.Generic;
using System.Text;


class Human
{
    private string firstname;
    private string lastname;

    public Human(string firstname, string lastname)
    {
        this.FirstName = firstname;
        this.LastName = lastname;
    }

    public string FirstName
    {
        get => this.firstname;

        set
        {
            string input = value;

            if (Char.IsLower(value,0))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {input}");
            }

            if(value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: {input}");
            }

            this.firstname = value;
        }
    }

    public string LastName
    {
        get => this.lastname;

        set
        {
            string input = value;

            if (Char.IsLower(value, 0))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {input}");
            }

            if (value.Length < 2)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: {input}");
            }

            this.lastname = value;
        }
    }
}

