using System;
using System.Collections.Generic;
using System.Text;


class Tire
{
    private double tire1pressure;
    private double tire1age;
    private double tire2pressure;
    private double tire2age;
    private double tire3pressure;
    private double tire3age;
    private double tire4pressure;
    private double tire4age;

    public Tire(double tire1pressure, double tire1age, double tire2pressure, double tire2age, double tire3pressure, double tire3age, double tire4pressure, double tire4age)
    {
        this.Tire1pressure = tire1pressure;
        this.Tire1age = tire1age;
        this.Tire2pressure = tire2pressure;
        this.Tire2age = tire2age;
        this.Tire3pressure = tire3pressure;
        this.Tire3age = tire3age;
        this.Tire4pressure = tire4pressure;
        this.Tire4age = tire4age;
    }

    public double Tire1pressure { get => tire1pressure; set => tire1pressure = value; }
    public double Tire1age { get => tire1age; set => tire1age = value; }
    public double Tire2pressure { get => tire2pressure; set => tire2pressure = value; }
    public double Tire2age { get => tire2age; set => tire2age = value; }
    public double Tire3pressure { get => tire3pressure; set => tire3pressure = value; }
    public double Tire3age { get => tire3age; set => tire3age = value; }
    public double Tire4pressure { get => tire4pressure; set => tire4pressure = value; }
    public double Tire4age { get => tire4age; set => tire4age = value; }

    public bool PressureUnder1Percent()
    {
        bool isLessThan1 = false;

        if (this.tire1pressure < 1)
        {
            isLessThan1 = true;
        }
        else if (this.tire2pressure < 1)
        {
            isLessThan1 = true;
        }
        else if(this.tire3pressure < 1)
        {
            isLessThan1 = true;
        }
        else if(this.tire4pressure < 1)
        {
            isLessThan1 = true;
        }

        return isLessThan1;

    }
}

