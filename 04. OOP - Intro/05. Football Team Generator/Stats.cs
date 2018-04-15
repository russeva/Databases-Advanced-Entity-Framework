using System;
using System.Collections.Generic;
using System.Text;



class Stats
{
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Stats(int endurance,int sprint,int dribble, int passing, int shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public int Endurance
    {
        get => this.endurance;

        private set
        {
            string currentStat = value.ToString();
            if(value < 0 || value > 100)
            {
                throw new ArgumentException($"{currentStat} should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get => this.sprint;

        private set
        {
            string currentStat = value.ToString();
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{currentStat} should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get => this.dribble;

        private set
        {
            string currentStat = value.ToString();
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{currentStat} should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }

    public int Passing
    {
        get => this.passing;

        private set
        {
            string currentStat = value.ToString();
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{currentStat} should be between 0 and 100.");
            }
            this.passing = value;
        }
    }

    public int Shooting
    {
        get => this.shooting;

        private set
        {
            string currentStat = value.ToString();
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{currentStat} should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }
}

