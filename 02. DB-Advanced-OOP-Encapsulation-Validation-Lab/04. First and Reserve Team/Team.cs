using System;
using System.Collections.Generic;
using System.Text;


class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.Name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public string Name
    {
        get => this.name;
        set => this.Name = value;
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get
        {
            return new List<Person>(this.firstTeam);
        }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get
        {
            return new List<Person>(this.reserveTeam);
        }
    }

    public void AddPlayer(Person currentPlayer)
    {
        if(currentPlayer.Age > 40)
        {
            this.reserveTeam.Add(currentPlayer);
        }
        else
        {
            this.firstTeam.Add(currentPlayer);
        }
    }

   
}

