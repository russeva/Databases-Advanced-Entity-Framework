using System;
using System.Collections.Generic;
using System.Text;


class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire tires;

    public Car(string model, Engine engine, Cargo cargo, Tire tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }

    public string Model
    {
        get => this.model;

        set => this.model = value;
    }


    public Engine Engine
    {
        get => this.engine;

        set => this.engine = value;
    }


    public Cargo Cargo
    {
        get => this.cargo;

        set => this.cargo = value;
    }


    public Tire Tires
    {
        get => this.tires;

        set => this.tires = value;
    }

}

