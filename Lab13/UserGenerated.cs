﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab13
{
    class UserGenerated : Player
    {
        public UserGenerated()
        {
            GetName();
        }
        public override Roshambo GenerateRoshambo()
        {
            Console.WriteLine("Make your decision:");
            int i = 1;
            foreach (Roshambo rps in Enum.GetValues(typeof(Roshambo)))
            {
                Console.WriteLine($"{i}: {rps}");
                i++;
            }
            int rpsDecision;
            while (!Int32.TryParse(Console.ReadLine(), out rpsDecision) || rpsDecision < 1 || rpsDecision > 3)
            {
            }
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
        private void GetName()
        {
            bool nameSelect = true;
            while (nameSelect)
            {
                Console.WriteLine("Please enter a name for your character: ");
                Name = Console.ReadLine();
                int decision = 0;
                NamePrompt();
                while (!Int32.TryParse(Console.ReadLine(), out decision) || decision < 1 || decision > 2)
                {
                    NamePrompt();
                }
                if (decision == 1)
                {
                    nameSelect = false;
                    Console.Clear();
                }
            }
        }
        private void NamePrompt()
        {
            Console.Clear();
            Console.WriteLine($"You entered: {Name}. Is that the name you would like to use?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
        }
    }
}