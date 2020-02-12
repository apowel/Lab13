using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    public class UserGenerated : Player
    {
        public UserGenerated()
        {
        }
        public static string GetName()
        {
            string name;
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter a name for your character: ");
                name = Console.ReadLine().Trim();
            }
            while (name.Equals(null) || name.Equals(""));
            int decision = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"You entered: {name}. Is that the name you would like to use?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
            }
            while ((!Int32.TryParse(Console.ReadLine(), out decision) || decision < 1 || decision > 2));
            if (decision == 1)
            {
                Console.Clear();
                return name;
            }
            else
            {
                return GetName();
            }
        }
        public override Roshambo GenerateRoshambo()
        {
            RPSPrompt();
            int rpsDecision;
            while (!Int32.TryParse(Console.ReadLine(), out rpsDecision) || rpsDecision < 1 || rpsDecision > 3)
            {
                Console.Clear();
                Console.WriteLine("That was not a valid input");
                RPSPrompt();
            }
            Console.Clear();
            if (rpsDecision == 1)
            {
                return Roshambo.Rock;
            }
            else if (rpsDecision == 2)
            {
                return Roshambo.Paper;
            }
            else
            {
                return Roshambo.Sissors;
            }
        }
        public void NamePrompt()
        {
            Console.Clear();
            Console.WriteLine($"You entered: {Name}. Is that the name you would like to use?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
        }
        private void RPSPrompt()
        {
            Console.WriteLine("Make your decision:");
            int i = 1;
            foreach (Roshambo rps in Enum.GetValues(typeof(Roshambo)))
            {
                Console.WriteLine($"{i}: {rps}");
                i++;
            }
        }
    }
}