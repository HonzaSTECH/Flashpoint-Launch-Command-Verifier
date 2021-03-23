using System;
using System.IO;
using System.Net;

namespace Flashpoint_Launch_Command_Verifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Flashpoint Launch Command Verifier by Shady";

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Fetching the database, this should only take a few seconds...");
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://bluebot.unstable.life/launch-commands");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            Console.WriteLine("Successfully fetched database of launch commands");
            Console.ResetColor();

            while (true)
            {
                Console.Write("\n\n");
                Console.WriteLine("Enter the launch command you want to verify:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string launchConmmand = Console.ReadLine();

                Console.Clear();
                Console.WriteLine(launchConmmand);

                if (content.Contains(launchConmmand))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This launch command is already present in the database.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("This launch command is unique.");
                }

                Console.ResetColor();
            }
        }
    }
}
