using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KeyboardPressCounter
{
    class Program
    {
        static Dictionary<char, int> count = new Dictionary<char, int>();
        static List<string> keywords = new List<string>();
        static string countFilePath = @"C:\Users\Selviniah\Desktop\BusService_ForReview_6.0\Keyboardpress.txt";
        static string keywordsFilePath = @"C:\Users\Selviniah\Desktop\BusService_ForReview_6.0\Keywords.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to stop...");

            while (!Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    char keyChar = Char.ToLower(keyInfo.KeyChar);
                    if (!count.ContainsKey(keyChar))
                    {
                        count.Add(keyChar, 1);
                    }
                    else
                    {
                        count[keyChar]++;
                    }
                    if (Char.IsWhiteSpace(keyChar) || keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        string word = String.Concat(keywords.LastOrDefault(), " ").Trim();
                        if (!String.IsNullOrWhiteSpace(word))
                        {
                            keywords.Add(word);
                            SaveKeywordsToFile();
                        }
                    }
                    else
                    {
                        string word = String.Concat(keywords.LastOrDefault(), keyChar).Trim();
                        if (keywords.Count == 0)
                        {
                            keywords.Add(word);
                        }
                        else
                        {
                            keywords[keywords.Count - 1] = word;
                        }
                    }
                    SaveCountsToFile();
                }
            }
        }

        static void SaveCountsToFile()
        {
            List<string> lines = new List<string>();
            foreach (var item in count.OrderBy(i => i.Key))
            {
                lines.Add(item.Key + " = " + item.Value);
            }
            File.WriteAllLines(countFilePath, lines);
        }

        static void SaveKeywordsToFile()
        {
            List<string> lines = new List<string>();
            foreach (var word in keywords)
            {
                string line = $"{DateTime.Now.ToString()} {word.Replace(' ', '_')}";
                if (Char.IsWhiteSpace(word.Last()))
                {
                    line += " ";
                }
                lines.Add(line);
            }
            string lastWord = keywords.LastOrDefault();
            if (!String.IsNullOrEmpty(lastWord) && (lastWord.EndsWith(" ") || lastWord.EndsWith("\t")))
            {
                lines[lines.Count - 1] = lines[lines.Count - 1].TrimEnd() + " ";
            }
            File.AppendAllLines(keywordsFilePath, lines);
        }





    }
}
