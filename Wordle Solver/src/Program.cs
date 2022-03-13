using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Title = "Wordle Tings";
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Wordle Tings");
                Console.WriteLine();
                Console.WriteLine("1) Wordle Guesser");
                Console.WriteLine("2) Best wordle starter word calculator (Takes like 30 mins to process but looks cool ig)");
                Console.WriteLine("3) Wordle Lookup (Find today's wordle + List of all future wordles + past wordles)");
                Console.WriteLine("");
                bool valid = false;
                Console.ResetColor();
                Console.WriteLine("Input: ");
                while (!valid)
                {
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Guesser.Run();
                        valid = true;
                    }
                    else if (input == "2")
                    {
                        Probability.Run();
                        valid = true;
                    }
                    else if(input == "3")
                    {
                        WordleLookup.Init();
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input u idiot i cba i even have to type this its literally one of three numbers pull urself together");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Input: ");
                        valid = false;
                    }
                }
            }
            WordleLookup.Init();
            //Probability.Run();
            Console.ReadKey();
            Guesser.Run();
            Console.ReadKey();
        }
    }
}
