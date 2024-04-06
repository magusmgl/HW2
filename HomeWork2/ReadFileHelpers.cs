﻿using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

internal static class ReadFileHelpers
{
    public static string ReadAllWordsInFile()
    {
        string textFile = "C:\\Users\\magus_m13d1h2\\OneDrive\\Documents\\test.txt";
        Console.WriteLine(File.Exists(textFile) ? "File exists" : "File does not exists");
        var textFromFile = string.Empty;
        if (File.Exists(textFile))
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                textFromFile = sr.ReadToEnd();
            }
        }
        return textFromFile;
    }

    public static void GetWordsWithMaxDigits(string textFromFile)
    {
        List<string> words = SpiltTextIntoWords(textFromFile);
        var allWordsWithMaxDigits = new List<string>();
        var maxDigitsInWords = words.Max(word => CountDigitsInWord(word));

        foreach (string word in words)
        {
            if (CountDigitsInWord(word) == maxDigitsInWords && !allWordsWithMaxDigits.Contains(word))
            {
                allWordsWithMaxDigits.Add(word);
            }
        }
        Console.WriteLine($"Слова содержащие максимальное количество цифр: {String.Join(", ", allWordsWithMaxDigits)}.");
    }

    public static void GetLongestWordAndItsNumOccurrences(string textFromFile)
    {
        List<string> words = SpiltTextIntoWords(textFromFile);
        int lenghtOfLongestWord = words.Max(word => word.Length);

        foreach (string word in words)
        {
            if (word.Length == lenghtOfLongestWord)
            {
                Console.WriteLine($"Самое длинное слово - {word}, оно содержит  {word.Length} букв{GetEndsOfWord(word.Length)}.");
            }
        }
    }

    private static int CountDigitsInWord(string word)
    {
        return word.Where(c => char.IsDigit(c)).Count();
    }

    private static string GetEndsOfWord(int lenghtWord)
    {
        return lenghtWord % 10 > 0 && lenghtWord % 10 < 5 ? "ы" : string.Empty;
    }

    private static List<string> SpiltTextIntoWords(string text)
    {
        string pattern = @"\b(\w+)\b";

        List<string> words = Regex
            .Matches(text, pattern)
            .Where(match => match.Success)
            .Select(match => match.Value)
            .ToList();

        return words;
    }

    private static string ReplaceNumbersWithNumeralsInWord(string word)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var ch in word)
        {
            if (!char.IsDigit(ch))
            {
                sb.Append(GetNumeral(ch));
            }
            sb.Append(ch);
        }

        return sb.ToString();
    }

    private static string GetNumeral(char ch)
    {
        return int.Parse(ch.ToString()) switch
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
            9 => "девять",
        };
    }
}