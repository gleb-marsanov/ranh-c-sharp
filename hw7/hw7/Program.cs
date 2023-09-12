using System.Text;
using System.Text.RegularExpressions;

namespace hw7;

internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Введите предложение: ");
        string sentence = Console.ReadLine()!;

        MatchCollection words = SplitString(sentence);
        WriteWordsToConsole(words);
    }

    private static void WriteWordsToConsole(MatchCollection words) =>
        Console.WriteLine(string.Join('\n', words));

    private static MatchCollection SplitString(string sentence) => 
        Regex.Matches(sentence, @"\b\w+\b", RegexOptions.IgnoreCase);
}