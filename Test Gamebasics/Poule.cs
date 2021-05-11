using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Gamebasics
{
    class Poule
    {
        public Team TeamOne;
        public Team TeamTwo;
        public Team TeamThree;
        public Team TeamFour;

        public Poule(Team One, Team Two, Team Three, Team Four)
        {
            this.TeamOne = One;
            this.TeamTwo = Two;
            this.TeamThree = Three;
            this.TeamFour = Four;
        }

        // Initiates the matches of round one 
        public void RoundOne()
        {
            Console.WriteLine("Round one");
            SimulateMatch(TeamOne, TeamTwo);
            SimulateMatch(TeamThree, TeamFour);
        }

        // Initiates the matches of round two
        public void RoundTwo()
        {
            Console.WriteLine("Round Two");
            SimulateMatch(TeamOne, TeamThree);
            SimulateMatch(TeamTwo, TeamFour);
        }

        // Initiates the matches of round three
        public void RoundThree()
        {
            Console.WriteLine("Round Three");
            SimulateMatch(TeamOne, TeamFour);
            SimulateMatch(TeamTwo, TeamThree);
        }

        // Simulates a match between two teams
        public void SimulateMatch(Team TeamA, Team TeamB)
        {
            int TeamAGoals = GenerateGoals(TeamA);
            TeamA.GoalsFor += TeamAGoals;
            TeamB.GoalsAgainst += TeamAGoals;
            int TeamBGoals = GenerateGoals(TeamB);
            TeamB.GoalsFor += TeamBGoals;
            TeamA.GoalsAgainst += TeamBGoals;
            switch (TeamAGoals)
            {
                case var expression when TeamAGoals < TeamBGoals:
                    TeamB.Points += 3;
                    break;
                case var expression when TeamAGoals > TeamBGoals:
                    TeamA.Points += 3;
                    break;
                default:
                    TeamA.Points += 1;
                    TeamB.Points += 1;
                    break;
            }
            Console.WriteLine(TeamA.Name + " " + TeamAGoals + " - " + TeamB.Name + " " + TeamBGoals);

        }

        // Generates a random amount of goals for a team
        public int GenerateGoals(Team team)
        {
            Random rnd = new Random();
            return rnd.Next(0, (team.Strength + 1));
        }

        // Calculates the rankings of the poule
        public List<Team> CalculateRankings(List<Team> list)
        {
            int MaxPoints = int.MinValue;
            List<Team> RankedList = new List<Team>();
            while (list.Any())
            {
                foreach (Team team in list)
                {
                    if (team.Points > MaxPoints)
                    {
                        MaxPoints = team.Points;
                    }
                }
                Team removal;
                var ItemToRemove = list.Where(r => r.Points == MaxPoints);
                if (ItemToRemove.Count() > 1)
                {
                    removal = GetHighestGoals(ItemToRemove);
                }
                else
                {
                    removal = ItemToRemove.First();
                }
                RankedList.Add(removal);
                list.Remove(removal);
                MaxPoints = int.MinValue;
            }

            return RankedList;
        }

        // Returns the team that has the highest goal difference
        private Team GetHighestGoals(IEnumerable<Team> itemToRemove)
        {
            int MaxGoals = int.MinValue;
            foreach (Team team in itemToRemove)
            {
                if (team.GetGoalDifference() > MaxGoals)
                {
                    MaxGoals = team.GetGoalDifference();
                }
            }
            return itemToRemove.First(r => r.GetGoalDifference() == MaxGoals);
        }

    }
}
