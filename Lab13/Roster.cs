using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Lab13
{
    [XmlInclude(typeof(Dwayne))]
    [XmlInclude(typeof(UserGenerated))]
    [XmlInclude(typeof(Randolph))]
    [Serializable()]
    public class Roster
    {
        public List<Player> users;
        public List<Player> npcRoster;
    
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
