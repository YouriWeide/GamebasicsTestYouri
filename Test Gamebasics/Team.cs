using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Gamebasics
{
    class Team
    {
        public String Name;
        public int Points;
        public int Strength;
        public int GoalsFor;
        public int GoalsAgainst;

        public Team(String name, int strength)
        {
            this.Name = name;
            this.Strength = strength;
        }

        // Returns the goals difference of the team
        public int GetGoalDifference()
        {
            return (this.GoalsFor - this.GoalsAgainst);
        }
    }
}
