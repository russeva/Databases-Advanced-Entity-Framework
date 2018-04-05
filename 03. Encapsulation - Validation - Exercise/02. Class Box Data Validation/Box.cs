using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get => this.length;

        private set
        {
            if (value < 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
            }
            else
            {
                this.length = value;
            }
        }
    }

    public double Width
    {
        get => this.width;

        private set
        {
            if (value < 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
            }
            else
            {
                this.width = value;
            }
        }
    }

    public double Height
    {
        get => this.height;

        private set
        {
            if (value < 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
            }
            else
            {
                this.height = value;
            }
        }
    }

    public double GetSurfaceArea()
    {
        var surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        return surfaceArea;
    }

    public double GetLateralSurfaceArea()
    {
        var lateralSurfaceArea = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        return lateralSurfaceArea;
    }

    public double GetVolume()
    {
        var voulume = this.Length * this.Height * this.Width;
        return voulume;
    }


}
