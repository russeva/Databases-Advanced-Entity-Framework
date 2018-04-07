using System;
using System.Collections.Generic;
using System.Text;



class Student : Human
{
    private double facultynumber;

        public Student(string firstname, string lastname,double facultynumber)
        :base(firstname, lastname)
    {
        this.FacultyNumber = facultynumber;
    }

    public double FacultyNumber
    {
        get => this.facultynumber;

        set
        {
            if(value.ToString().Length <= 4 || value.ToString().Length >= 9)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultynumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {base.FirstName} {Environment.NewLine}" +
            $"Last Name: {base.LastName} {Environment.NewLine}" +
            $"Faculty number: {this.FacultyNumber} {Environment.NewLine}";
    }
}

