using System;

namespace Lab13
{
    class RoshamboApp
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public RoshamboApp()
        {
            
            Player1 = new UserGenerated();
            Play();

        }
        public void Play()
        {
            SelectOpponent();
            Console.Clear();

            Console.WriteLine("Users turn");
            Roshambo p1Throw = Player1.GenerateRoshambo();
            
            Roshambo p2Throw = Player2.GenerateRoshambo();
            Console.WriteLine($"{Player2.Name}'s turn");
            Console.WriteLine($"{Player2.Name} played {p2Throw}");
            DecideWinner((int)p1Throw, (int)p2Throw);
            DisplayRecords();
            PlayAgainPrompt();
        }
        public void SelectOpponent()
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Please select and opponent: Dwayne or Randolph");
                string input = Console.ReadLine().ToLower().Trim();

                if (input == "dwayne")
                {
                    Player2 = new Dwayne();
                    repeat = false;
                }
                else if (input == "randolph")
                {
                    Player2 = new Randolph();
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("That was not a valid input");
                }
            }
        }
        private void DecideWinner(int p1Throw, int p2Throw)
        {
            int[,] array2D = new int[3, 3] { { 0, -1, 1 }, { 1, 0, -1 }, { -1, 1, 0 } };
            int result = array2D[p1Throw, p2Throw];
            if (result == 0)
            {
                Console.WriteLine("It was a draw!");
                Player1.Ties++;
                Player2.Ties++;
            }
            else if (result == 1)
            {
                Console.WriteLine("You win!");
                Player1.Wins++;
                Player2.Losses++;
            }
            else
            {
                Console.WriteLine($"{Player2} wins!");
                Player1.Losses++;
                Player2.Wins++;
            }
        }
        private void DisplayRecords()
        {
            while (true)
            {
                Console.WriteLine("Would you like to see the win/loss records?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
                int decision = 0;
                while (!Int32.TryParse(Console.ReadLine(), out decision) || decision < 1 || decision > 2)
                {
                    Console.WriteLine("That was not a valid selection");
                }
                if (decision == 1)
                {
                    Console.WriteLine($"Your wins: {Player1.Wins}\nYour losses:{Player1.Losses}");
                    Console.WriteLine($"{Player2.Name}'s wins: {Player2.Wins}\n{Player2.Name}'s losses:{Player2.Losses}");
                    return;
                }
                if (decision == 2)
                {
                    Console.Clear();
                    return;
                }
            }
        }
        private void PlayAgainPrompt()
        {
            while (true)
            {
                Console.WriteLine("Would you like to play again? (y/n)");
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "y")
                {
                    Play();
                    return;
                }
                else if (input == "n")
                {
                    Console.WriteLine("Goodbye");
                    return;
                }
                else
                {
                    Console.WriteLine("That doesn't make sense");
                }
            }
        }
    }
}
