using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Gamebasics
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Team Feyenoord = new Team("Feyenoord", 2);
            Team Ajax = new Team("Ajax", 3);
            Team PSV = new Team("PSV", 2);
            Team AZ = new Team("AZ", 1);
            List<Team> List= new List<Team>()
            {
               Feyenoord,
               Ajax,
               PSV,
               AZ
            };
            Poule poule = new Poule(Feyenoord, Ajax, PSV, AZ);
            poule.RoundOne();
            poule.RoundTwo();
            poule.RoundThree();
            List<Team> RankedList = poule.CalculateRankings(List);
            int i = 1;
            Console.WriteLine("Rankings");
            foreach (Team team in RankedList)
            {
                Console.WriteLine(i + " " + team.Name);
                i++;
            }
        }
    }
}
