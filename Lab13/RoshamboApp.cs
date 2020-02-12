using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab13
{
    class RoshamboApp
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        Roster roster = new Roster();
        
        public RoshamboApp()
        {
            GetRoster();
            MainMenu();
        }
        private void GetRoster()
        {
            if (File.Exists("Roster.XML"))
            {
                roster = ReadFromXmlFile("Roster.XML");
            }
            else
            {
                roster = new Roster();
                roster.users = new List<Player>();
                roster.npcRoster = new List<Player>
                {
                    new Dwayne(),
                    new Randolph()
                };
            }
        }
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("Please type the number of an option below:\n");
            Console.WriteLine("1: Play");
            Console.WriteLine("2: Show Scores");
            Console.WriteLine("3: Save and Exit Game");
            Console.WriteLine("4: Exit Without Saving");
            if (File.Exists("Roster.XML"))
            {
                Console.WriteLine("\n0: Delete Saved Data");
            }
            GetMenuInput();
        }
        private void GetMenuInput()
        {
            string decision = Console.ReadLine().ToLower().Trim();
            while (true)
            {
                if (decision == "1")
                {
                    CharacterSelect();
                    Play();
                }
                if (decision == "2")
                {
                    DisplayRecords();
                }
                if (decision == "3")
                {
                    WriteXML(roster);
                    Environment.Exit(0);
                }
                if (decision == "4")
                {
                    Environment.Exit(0);
                }
                if (decision == "0")
                {
                    if (File.Exists("Roster.XML"))
                    {
                        File.Delete("Roster.XML");
                        GetRoster();
                        MainMenu();
                    }
                }
                else
                {
                    MainMenu();
                }
            }
        }
        private void Play()
        {
            SelectOpponent();
            Console.Clear();

            Console.WriteLine("Users turn");
            Roshambo p1Throw = Player1.GenerateRoshambo();

            Roshambo p2Throw = Player2.GenerateRoshambo();
            Console.WriteLine($"{Player2.Name}'s turn");
            Console.WriteLine($"{Player2.Name} played {p2Throw}");
            DecideWinner((int)p1Throw, (int)p2Throw);
            PlayAgainPrompt();
        }
        private void CharacterSelect()
        {
            Console.Clear();
            Console.WriteLine("Select a character or create a new one: ");
            roster.GetUsers();
            Console.WriteLine($"{roster.users.Count + 1}: Create New Character");
            int decision = 0;
            while (!Int32.TryParse(Console.ReadLine(), out decision) 
                || decision < 1 || decision > (roster.users.Count + 1))
            {
                Console.Clear();
                Console.WriteLine("That was not a Valid input");
                roster.GetUsers();
                Console.WriteLine($"{roster.users.Count + 1}: Create New Character");
            }
            try
            {
                Player1 = roster.users[decision - 1];
            }
            catch
            {
                Player1 = new UserGenerated();
                Player1.Name = UserGenerated.GetName();
                roster.users.Add(Player1);
            }
        }
        private void SelectOpponent()
        {
            Console.Clear();
            Console.WriteLine("Please select an opponent: ");
            roster.GetNPCs();
            int decision;
            while (!Int32.TryParse(Console.ReadLine(), out decision)
                || decision < 1 || decision > (roster.npcRoster.Count))
            {
                Console.Clear();
                Console.WriteLine("That was not a Valid input");
                roster.GetNPCs();
            }
            try
            {
                Player2 = roster.npcRoster[decision - 1];
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("That was not a valid input. Please Try Again.");
                SelectOpponent();
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
                Console.WriteLine($"{Player2.Name} wins!");
                Player1.Losses++;
                Player2.Wins++;
            }
            PlayAgainPrompt();
        }
        private void DisplayRecords()
        {
            Console.Clear();
            if (roster.users.Count > 0)
            {
                Console.WriteLine("Here are the current win/loss records: \n");
                Console.WriteLine("Player scores: ");
                foreach (Player user in roster.users)
                {
                    Console.WriteLine($"{user.Name}'s wins: {user.Wins}\n{user.Name}'s losses:{user.Losses}\n");
                    Console.WriteLine();
                }

                Console.WriteLine("NPC Scores: ");
                foreach (Player npc in roster.npcRoster)
                {
                    Console.WriteLine($"{npc.Name}'s wins: {npc.Wins}\n{npc.Name}'s losses:{npc.Losses}\n");
                }
            }
            else
            {
                Console.WriteLine("No games have been recorded yet.");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            MainMenu();
        }
        private void PlayAgainPrompt()
        {
            while (true)
            {
                Console.WriteLine("Would you like to play again?\n1: Continue as current character\n2: Return to Main menu");
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "1")
                {
                    Play();
                }
                else if (input == "2")
                {
                    MainMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("That was not a valid input");
                    PlayAgainPrompt();
                }
            }
        }
        private static void WriteXML(Roster roster)
        {
            var path = "Roster.XML";
            XmlSerializer serializer = new XmlSerializer(typeof(Roster));
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, roster);
            writer.Close();
        }
        private static Roster ReadFromXmlFile(string path)
        {
            object obj = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Roster));
            if (File.Exists(path))
            {
                TextReader textReader = new StreamReader(path);
                obj = serializer.Deserialize(textReader);
                textReader.Close();
            }
            return (Roster)obj;
        }
    }
}
