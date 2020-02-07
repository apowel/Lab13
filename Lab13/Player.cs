using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public abstract class Player
    {
        private Roshambo roshamboValue;
        private string name;

        public Roshambo RoshamboValue { get => roshamboValue; set => roshamboValue = value; }
        public string Name { get => name; set => name = value; }
        public enum Roshambo
        {
            Rock,
            Paper,
            Sissors
        }
        public Player()
        {

        }
        public abstract Roshambo GenerateRoshambo();
    }
}
