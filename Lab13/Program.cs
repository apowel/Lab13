using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            UserGenerated user = new UserGenerated();
            Console.WriteLine(user.GenerateRoshambo());
            Console.ReadKey();
        }
    }
}
