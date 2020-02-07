using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public class Randolph : Player
    {
        public Randolph()
        {
            Name = "Randolph";
        }
        public override Roshambo GenerateRoshambo()
        {
            Random selectRoshambo = new Random();
            return ((Roshambo)selectRoshambo.Next(0, 3));
        }
    }
}
