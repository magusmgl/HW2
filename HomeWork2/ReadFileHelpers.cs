using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.Cryptography;

internal static class ReadFileHelpers
{
    public static List<string> ReadAllWordsInFile()
    {
        string textFile = "C:\\Users\\magus_m13d1h2\\OneDrive\\Documents\\test.txt";
        Console.WriteLine(File.Exists(textFile) ? "File exists" : "File does not exists");
        
        List<string> wordsWithNumbers = new List<string>();
        if (File.Exists(textFile))
        {
            using (StreamReader sr = new StreamReader(textFile))
            {
                var text = sr.ReadToEnd();

                string pattern = @"\b(\w+)\b";
                //wordsWithNumbers.Add(match.Groups[1].Value);
                //string patternIncludeNumbers = @"\b([a-zA-Z]*\d+[a-zA-Z]*)\b";
                wordsWithNumbers
                    .AddRange(Regex.Matches(text, pattern)
                    .Where(match => match.Success)
                    .Select(match => match.Value));
            }
        }
        Console.WriteLine(string.Join(", ", wordsWithNumbers));
        return wordsWithNumbers;

    }

    
    public static void GetWordsWithMaxDigits(List<string> words)
    {
        List<string> allWordsWithMaxDigits = new List<string>();
        int maxDigitsInWords = words.Max(word => CountDigitsInWord(word));

        foreach (string word in words) 
        { 
              if (CountDigitsInWord(word) == maxDigitsInWords && !allWordsWithMaxDigits.Contains(word)) 
              {
                allWordsWithMaxDigits.Add(word);
              }        
        }
        Console.WriteLine($"Слова содержащие максимальное количество цифр: {String.Join(", ", allWordsWithMaxDigits)}.");
    }

    private static int CountDigitsInWord(string word)
    {
        return word.Where(c => char.IsDigit(c)).Count();
    }

    public static void GetLongestWordAndItsNumOccurrences(List<string> words)
    {
        int lenghtOfLongestWord = words.Max(word => word.Length);

        foreach (string word in words)
        {
            if (word.Length == lenghtOfLongestWord)
            {
                Console.WriteLine($"Самое длинное слово - {word}, оно содержит  {word.Length} букв{GetEndsOfWord(word.Length)}.");
            }
        }
    }

    private static string GetEndsOfWord(int lenghtWord)
    {
        return lenghtWord % 10 > 0 && lenghtWord % 10 < 5 ? "ы" : string.Empty;
    }
}