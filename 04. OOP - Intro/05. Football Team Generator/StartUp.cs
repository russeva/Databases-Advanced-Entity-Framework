using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Football_Team_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input;
                List<Team> dbTeams = new List<Team>();
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] arrgs = input.Split(';');

                    switch(arrgs[0])
                    {
                        case "Team":
                            string teamName = arrgs[1];
                            Team currentTeam = new Team(teamName);
                            dbTeams.Add(currentTeam);
                            break;
                        case "Add":
                            teamName = arrgs[1];
                            string playersName = arrgs[2];

                            int endurance = int.Parse(arrgs[3]);
                            int sprint = int.Parse(arrgs[4]);
                            int dribble = int.Parse(arrgs[5]);
                            int passing = int.Parse(arrgs[6]);
                            int shooting = int.Parse(arrgs[7]);

                            Stats playerStats = new Stats(endurance,sprint,dribble,passing,shooting);
                            Player newPlayer = new Player(playersName,playerStats);
                            

                            int indexT = dbTeams.FindIndex(x => x.Name == teamName);
                            dbTeams[indexT].AddPlayer(newPlayer);
                            break;
                        case "Remove":
                            teamName = arrgs[1];
                            playersName = arrgs[2];
                            indexT = dbTeams.FindIndex(x => x.Name == teamName);
                            dbTeams[indexT].RemovePlayer(playersName);
                            break;
                        case "Rating":
                            teamName = arrgs[1];
                            indexT = dbTeams.FindIndex(x => x.Name == teamName);
                            Console.WriteLine(dbTeams[indexT].GetSkillLevel().ToString());

                            break;
                    }

                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
