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
        // string textFile = "C:\\Users\\magus_m13d1h2\\OneDrive\\Documents\\test.txt";
        var textFile = "C:\\Users\\m.glazunov\\Documents\\test.txt";

        Console.WriteLine(File.Exists(textFile) ? "File exists" : "File does not exists");
        var textFromFile = string.Empty;
        if (File.Exists(textFile))
        {
            using var sr = new StreamReader(textFile);
            textFromFile = sr.ReadToEnd();
        }

        return textFromFile;
    }


    public static List<string> GetSentencesFromText(string textFromFile)
    {
        char[] signs = ['.', '?', '!'];
        var sentences = new List<string>();
        var start = 0;
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


    public static List<string> SpiltTextIntoWords(string text)
    {
        var pattern = @"\b(\w+)\b";

        List<string> words = Regex
            .Matches(text, pattern)
            .Where(match => match.Success)
            .Select(match => match.Value)
            .ToList();

        return words;
    }
}