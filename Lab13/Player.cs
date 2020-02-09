using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public enum Roshambo
    {
        Rock,
        Paper,
        Sissors
    }
    public abstract class Player
    {
        private Roshambo roshamboValue;
        private string name;

        public Roshambo RoshamboValue { get => roshamboValue; set => roshamboValue = value; }
        public string Name { get => name; set => name = value; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }

        public Player()
        {

        }
        public abstract Roshambo GenerateRoshambo();
    }
}
