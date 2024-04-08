using System.Text.RegularExpressions;

internal static class ReadFileHelpers
{
    public static string ReadTextInFile(string path)
    {
         //string textFile = "C:\\Users\\magus_m13d1h2\\OneDrive\\Documents\\test.txt";
        //var textFile = "C:\\Users\\m.glazunov\\Documents\\test.txt";
        using var sr = new StreamReader(path);
        
        return sr.ReadToEnd();
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