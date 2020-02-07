using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public class Dwayne : Player
    {
        public Dwayne()
        {
            Name = "Dwayne Johnson";
            RoshamboValue = Roshambo.Rock;
        }
        public override Roshambo GenerateRoshambo()
        {
            return RoshamboValue;
        }
    }
}
