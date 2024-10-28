using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\kyotzu\\Desktop\\Text1.txt";

            try
            {
                string text = File.ReadAllText(filePath);

                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                var words = noPunctuationText.ToLower()
                    .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    if (wordCount.ContainsKey(word))
                        wordCount[word]++;
                    else
                        wordCount[word] = 1;
                }

                var topWords = wordCount.OrderByDescending(w => w.Value)
                                         .Take(10);

                Console.WriteLine("Топ-10 слов по частоте:");
                foreach (var word in topWords)
                {
                    Console.WriteLine($"{word.Key}: {word.Value} раз(а)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
