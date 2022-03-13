using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    class Guesser
    {
        public static void Run()
        {
            Console.WriteLine("this is not complete bc im lazy idc cope");
            Console.WriteLine("Enter - for unknown letters, example: h-l-o");
            Console.WriteLine("Input:");
            var client = new WebClient();
            string contents = client.DownloadString("https://raw.githubusercontent.com/charlesreid1/five-letter-words/master/sgb-words.txt");
            string[] lines = contents.Split(Environment.NewLine.ToCharArray());
            string input = Console.ReadLine();
            List<string> VerifiedWords = new List<string>();
            for (int i = 0; i < lines.Length -1; i++)
            {
                string tword = lines[i];
                bool valid = true;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] != tword[j] && input[j] != '-')
                    {
                        valid = false;
                    }

                }
                if (valid)
                {
                    VerifiedWords.Add(tword);
                }
            }
            Console.WriteLine("List of potential words:");
            for (int j = 0; j < VerifiedWords.Count; j++)
            {
                Console.WriteLine(VerifiedWords[j]);
            }
        }
    }
}
