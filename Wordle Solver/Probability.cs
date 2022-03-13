using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    class Probability
    {
        public struct wordInfo {
            public string word;
            public int score;
        }

        public static void Run()
        {
            var client = new WebClient();
            string contents = client.DownloadString("https://raw.githubusercontent.com/charlesreid1/five-letter-words/master/sgb-words.txt");
            string[] lines = contents.Split(Environment.NewLine.ToCharArray());
            List<wordInfo> wordList = new List<wordInfo>();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < lines.Length-1; i++)
            {
                wordInfo tempMainWord;
                tempMainWord.score = 0;
                tempMainWord.word = lines[i];
                for (int j = 0; j < lines.Length; j++)
                {
                    string tempWord = lines[j];
                    for(int z = 0; z < tempWord.Length; z++)
                    {
                        if(tempMainWord.word[z] == tempWord[z])
                        {
                            tempMainWord.score+=1;
                        }
                    }
                    int percentComplete = (int)(0.5f + ((100f * i) / lines.Length));
                    Console.WriteLine($"{tempWord} | {tempMainWord.score} | {i} | {j} | %{percentComplete}");
                }
                wordList.Add(tempMainWord);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Processing complete");
            wordInfo highestInfo;
            highestInfo.word = "null";
            highestInfo.score = -1;
            int highest = 0;
            for (int j = 0; j < wordList.Count; j++)
            {
                if(wordList[j].score > highest)
                {
                    highest = wordList[j].score;
                    highestInfo = wordList[j];
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Found the most likely word: {highestInfo.word} | {highestInfo.score}");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
