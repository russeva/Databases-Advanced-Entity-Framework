using System;
using System.Collections.Generic;
using System.Text;


class Player
{
    private string name;
    protected internal Stats stats;

    public Player(string name,Stats stats)
    {
        this.Name = name;
        this.Stats = stats;
    }

    public string Name
    {
        get => this.name;

        private set => this.name = value;
    }

    internal Stats Stats
    {
        get => this.stats;

        set
        {

            this.stats = value;
        }
    }
}

