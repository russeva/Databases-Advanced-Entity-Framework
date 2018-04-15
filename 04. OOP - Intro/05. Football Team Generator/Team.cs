using System;
using System.Collections.Generic;
using System.Text;


class Team
{
    private List<Player> dbplayers;
    private string name;
    private double rating;

    public Team(string name)
    {
        this.DbPlayers = new List<Player>();
        this.Name = name;
        this.Rating = rating;
    }

    private List<Player> DbPlayers
    {
        get => this.dbplayers;

        set => this.dbplayers = value;
    }

    public string Name
    {
        get => this.name;

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("A name should not be empty.");
            }
            else if (value == "")
            {
                throw new ArgumentNullException("A name should not be empty.");
            }
            else if (value == " ")
            {
                throw new ArgumentNullException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public double Rating
    {
        get => this.rating;


        private set => this.rating = value;
    }

    public void AddPlayer(Player currentPlayer)
    {
        this.dbplayers.Add(currentPlayer);
    }

    public void RemovePlayer(string playersName)
    {
        int indexP = dbplayers.FindIndex(x => x.Name == playersName);
        Console.WriteLine($"Player {playersName} is not in the {this.Name} team.");
        dbplayers.RemoveAt(indexP);

    }

    public double GetSkillLevel()
    {
        double avrgSkill = 0;
        foreach (var currentPlayer in this.dbplayers)
        {
             avrgSkill += (currentPlayer.Stats.Dribble + currentPlayer.Stats.Endurance
                + currentPlayer.Stats.Passing + currentPlayer.Stats.Shooting
                + currentPlayer.Stats.Sprint) / 5.0;
        }
        return Math.Ceiling(avrgSkill);
    }

}

