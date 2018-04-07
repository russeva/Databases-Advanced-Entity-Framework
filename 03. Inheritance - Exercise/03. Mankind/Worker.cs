using System;
using System.Collections.Generic;
using System.Text;



class Worker : Human
{
    private double weeksalary;
    private double workhoursperday;
    private double salaryperhour;

    public Worker(string firstname, string lastname, double weeksalary ,double workinghoursperday)
        :base(firstname,lastname)
    {
        this.WeekSalary = weeksalary;
        this.WorkingHoursPerDay = workhoursperday;
    }

    public double WeekSalary
    {
        get => this.weeksalary;

        private set
        {
            if(value < 10)
            {
                throw new ArgumentException("Expected value mismatch!");
            }
            this.weeksalary = value;
        }
    }

    public double WorkingHoursPerDay
    {
        get => this.workhoursperday;

        private set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch!");
            }
            this.workhoursperday = value;
        }
    }

    public double SalaryPerHour
    {
        get => this.salaryperhour;

        private set
        {
            this.salaryperhour = this.weeksalary / (5 * this.workhoursperday);
        }
    }
    public override string ToString()
    {
        return $"First Name: {base.FirstName} {Environment.NewLine}" +
            $"Last Name: {base.LastName} {Environment.NewLine}" +
            $"Week Salary: {this.WeekSalary:f2}{Environment.NewLine}" +
            $"Hours per day: {this.WorkingHoursPerDay:f2} {Environment.NewLine}" +
            $"Salary per hour: {this.SalaryPerHour:f2}";

    }

}

