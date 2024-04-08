using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork2
{
    public static class TextHandler
    {
        public static void InsertNumeralsInText(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            string[] chunks = textFromFile.Split(" ", StringSplitOptions.None);
            for (int i = 0; i < chunks.Length; i++)
            {
                if (CountDigitsInWord(chunks[i]) > 0)
                {
                    chunks[i] = ReplaceNumbersWithNumeralsInWord(chunks[i]);
                }
            }

            Console.WriteLine($"Текст после замены цифр на числитетельные:\n{string.Join(" ", chunks)}");
        }

        public static void GetWordsWithMaxDigits(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            List<string> words = ReadFileHelpers.SpiltTextIntoWords(textFromFile);
            var allWordsWithMaxDigits = new List<string>();
            var maxDigitsInWords = words.Max(_ => CountDigitsInWord(_));

            foreach (string word in words)
            {
                if (CountDigitsInWord(word) == maxDigitsInWords && !allWordsWithMaxDigits.Contains(word))
                {
                    allWordsWithMaxDigits.Add(word);
                }
            }

            Console.WriteLine(
                $"Слова содержащие максимальное количество цифр: {string.Join(", ", allWordsWithMaxDigits)}.");
        }

        public static void GetLongestWordAndItsNumOccurrences(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            List<string> words = ReadFileHelpers.SpiltTextIntoWords(textFromFile);
            var lengthOfLongestWord = words.Max(word => word.Length);
            foreach (var word in words.Where(word => word.Length == lengthOfLongestWord))
            {
                Console.WriteLine(
                                    $"Самое длинное слово - {word}, оно содержит {word.Length} букв{GetEndsOfWord(word.Length)}.");
            }
        }

        public static void GetWordsStartsAnsEndWithTheSameLetter(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            var words = ReadFileHelpers.SpiltTextIntoWords(textFromFile);
            Console.WriteLine("Cлова, начинающиеся и заканчивающиеся на одну и ту же букву: ");
            foreach (var word in words.Where(x => x.Length > 1 && x[0] == x[^1]).Distinct())
            {
                Console.Write($"{word.ToLower()}, ");
            }
        }

        public static void GetSentencesWithExclamationPoint(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            var sentences = ReadFileHelpers.GetSentencesFromText(textFromFile);
            Console.WriteLine("Восклицательные предложения в тексте: ");
            foreach (var sentence in sentences.Where(sentence => sentence.EndsWith('!')))
            {
                Console.WriteLine(sentence);
            }
        }

        public static void GetSentencesWithQuestionMark(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            var sentences = ReadFileHelpers.GetSentencesFromText(textFromFile);
            Console.WriteLine("Вопросительные предложения в тексте: ");
            foreach (var sentence in sentences.Where(sentence => sentence.EndsWith('?')))
            {
                Console.WriteLine(sentence);
            }
        }

        public static void GetSentencesWithoutWashedDown(string path)
        {
            var textFromFile = ReadFileHelpers.ReadTextInFile(path);
            var sentences = ReadFileHelpers.GetSentencesFromText(textFromFile);
            Console.WriteLine("Все предложения, не содержащие запятых: ");
            foreach (var sentence in sentences.Where(sentence => !sentence.Contains(',')))
            {
                Console.WriteLine(sentence);
            }
        }

        private static int CountDigitsInWord(string word)
        {
            return word.Where(c => char.IsDigit(c)).Count();
        }

        private static string GetEndsOfWord(int lengthWord)
        {
            return lengthWord % 10 > 0 && lengthWord % 10 < 5 ? "ы" : string.Empty;
        }

        private static string ReplaceNumbersWithNumeralsInWord(string word)
        {
            var sb = new StringBuilder();
            foreach (var charToAdd in word.Select(ch => !char.IsDigit(ch) ? ch.ToString() : GetNumeral(ch)))
            {
                sb.Append(charToAdd);
            }

            return sb.ToString();
        }

        private static string GetNumeral(char ch) => int.Parse(ch.ToString()) switch
        {
            0 => "ноль",
            1 => "один",
            2 => "два",
            3 => "три",
            4 => "четыре",
            5 => "пять",
            6 => "шесть",
            7 => "семь",
            8 => "восемь",
            9 => "девять"
        };
    }
}