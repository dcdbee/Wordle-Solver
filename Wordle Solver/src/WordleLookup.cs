using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    class WordleLookup
    {
        public static void Init()
        {
            var client = new WebClient();
            string contents = client.DownloadString("https://www.nytimes.com/games/wordle/main.bfba912f.js");
            string parsed = contents.Substring(contents.IndexOf("Ma=[") + 4, (contents.IndexOf("],Oa=")) - contents.IndexOf("Ma=[") - 4);

            string[] words = parsed.Split(',');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(1, words[i].Length - 2);
            }
            Console.WriteLine("Options:");
            Console.WriteLine("1: View today's wordle");
            Console.WriteLine("2: View the wordle for a specific day");
            Console.WriteLine("3: View all the wordles");
            Console.WriteLine("4: Menu");
            string choice = Console.ReadLine();
            bool valid = false;
            while (!valid)
            {
                if (choice == "1")
                {
                    DateTime now = DateTime.Now;
                    int day = 19;
                    int month = 6;
                    int year = 2021;
                    DateTime start = new DateTime(year, month, day);

                    TimeSpan t = now - start;
                    int NrOfDays = (int)t.TotalDays;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The wordle for today is {words[NrOfDays]}");
                    Console.ResetColor();
                }
                else if(choice == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Please enter the date for the wordle you wish to know (this can be the future). In the format dd/mm/yyyy.");
                    Console.WriteLine("if u do it the american way ur stupid and deserve the error u dont deserve no try catch <3");
                    Console.ForegroundColor = ConsoleColor.White;
                    string[] date = Console.ReadLine().Split('/');
                    int day = int.Parse(date[0]);
                    int month = int.Parse(date[1]);
                    int year = int.Parse(date[2]);
                    DateTime temp = new DateTime(year,month,day);

                    int day2 = 19;
                    int month2 = 6;
                    int year2 = 2021;
                    DateTime td = new DateTime(year2, month2, day2);

                    TimeSpan t = temp - td;
                    int NrOfDays = (int)t.TotalDays;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The wordle for {date[0]}/{date[1]}/{date[2]} is {words[NrOfDays]}");
                    Console.ResetColor();
                }
                else if(choice == "3")
                {
                    Console.WriteLine("LIST OF WORDS:");
                    for(int z = 0; z < words.Length; z++)
                    {
                        if (z == words.Length-1) Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Day #{z}: {words[z]}");
                    }
                    Console.ResetColor();
                    Console.WriteLine("Options:");
                    Console.WriteLine("1: View today's wordle");
                    Console.WriteLine("2: View the wordle for a specific day");
                    Console.WriteLine("3: View all the wordles");
                    Console.WriteLine("4: Menu");
                }
                else if(choice == "4")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
                if (!valid)
                {
                    Console.WriteLine("Input:");
                    choice = Console.ReadLine();
                }
            }
        }
    }
}
