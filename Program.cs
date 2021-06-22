using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\natay\Documents\yes.txt");

            var numberOfWords = NumberOfWords(text);
            Console.WriteLine("Number of words: {0}", numberOfWords);

            var averageWordLength = averageWords(text, numberOfWords);
            Console.WriteLine("Average word length: {0}", averageWordLength);

            WordInstances(text);
            AlphabetStart(text);
            
        

            //Calculates the total number of words within the file
            int NumberOfWords(string text)
            {
                int wordCount = 0;
                
                foreach(var word in text.Split(' '))
                {
                    wordCount++;
                }
                return wordCount;
            }

            //Calculates the average word length in the file
            //This is achieved by dividing the number of letters by the number of words
            float averageWords(string text, int wordCount)
            {
                int numberOfLetters = 0;

                foreach(var letter in text)
                {
                    numberOfLetters++;
                }

                float averageWordLength = numberOfLetters / wordCount;
                return averageWordLength;
            }

            //Counts the number of unique words that appear within the passage
            //Also outputs the most commonly used word throughout the passage
            void WordInstances(string text)
            {
                Dictionary<string, int> Instances = new Dictionary<string, int>();

                foreach(var word in text.Split(' '))
                {
                    if (Instances.ContainsKey(word))
                    {
                        int value = Instances[word];
                        Instances[word] = value + 1;
                    }
                    else
                    {
                        Instances.Add(word, 1);
                    }
                }

                foreach(KeyValuePair<string, int> kvp in Instances)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }

                var largestValue = Instances.Values.Max();
                var key = Instances.FirstOrDefault(x => x.Value == largestValue).Key;

                Console.WriteLine("The most common word used is: '{0}' with {1} uses throughout the passage", key, largestValue);
                
            }

            //Calculates how many words begin with each letter of the alphabet
            void AlphabetStart(string text)
            {
                Dictionary<char, int> alphabet = new Dictionary<char, int>();

                foreach(var word in text.Split(' '))
                {
                    var wordStart = word[0];

                    if (alphabet.ContainsKey(wordStart))
                    {
                        int value = alphabet[wordStart];
                        alphabet[wordStart] = value + 1;
                    }
                    else
                    {
                        alphabet.Add(wordStart, 1);
                    }
                }

                foreach(KeyValuePair<char, int> kvp in alphabet)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }
            }

            
        }
    }
}
