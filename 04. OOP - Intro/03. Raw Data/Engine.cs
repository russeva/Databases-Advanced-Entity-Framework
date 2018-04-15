using System;
using System.Collections.Generic;
using System.Text;

class Engine
{
    private int enginespeed;
    private int enginepower;

    public Engine(int enginespeed, int enginepower)
    {
        this.EngineSpeed = enginespeed;
        this.EnginePower = enginepower;

    }

    public int EngineSpeed
    {
        get  => this.enginespeed;

        set => this.enginespeed = value;
    }

    public int EnginePower
    {
        get => this.enginepower;

        set => this.enginepower = value;
    }
}

