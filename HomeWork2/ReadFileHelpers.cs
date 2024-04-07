using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;

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

    public static void InsertNumeralsInText(string textFromFile)
    {
        StringBuilder sb = new StringBuilder();
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

    private static List<string> GetSentencesFromText(string textFromFile)
    {
        char[] signs = ['.', '?', '!'];
        List<String> sentences = new List<string>();
        int start = 0;
        int position;
        do
        {
            position = textFromFile.IndexOfAny(signs, start);
            if (position >= 0)
            {
                sentences.Add(textFromFile.Substring(start, position - start + 1).Trim());
                start = position + 1;
            }
        } while (position > 0);
        return sentences;


    }
    public static void GetSentetencesWithExclamationPoint(string textFromFile)
    {
        var senteces = GetSentencesFromText(textFromFile);
        foreach (string sentence in senteces)
        {
            if (sentence.EndsWith('!'))
            {
                Console.WriteLine(sentence);
            }
        }
    }
    public static void GetSentetencesWithQuestionMark(string textFromFile)
    {
        var senteces = GetSentencesFromText(textFromFile);
        foreach (string sentence in senteces)
        {
            if (sentence.EndsWith('?'))
            {
                Console.WriteLine(sentence);
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
            var charToAdd = !char.IsDigit(ch) ? ch.ToString() : GetNumeral(ch);
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