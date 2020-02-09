using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab13
{
    class Roster
    {
        public List<Player> users = new List<Player>(){};
        public List<Player> npcRoster = new List<Player>()
        {
            new Dwayne(),
            new Randolph(),
        };
        public void GetUsers()
        {
            int i = 1;
            foreach (Player player in users)
            {
                Console.WriteLine($"{i}: {player.Name}");
                i++;
            }
        }
        public void GetNPCs()
        {
            int i = 1;
            foreach (Player player in npcRoster)
            {
                Console.WriteLine($"{i}: {player.Name}");
                i++;
            }
        }
    }
}
