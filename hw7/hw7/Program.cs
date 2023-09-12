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

        var words = SplitString(sentence);
        WriteEnumerableToConsole(words);
    }

    private static void WriteEnumerableToConsole(MatchCollection words) =>
        Console.WriteLine(string.Join('\n', words));

    private static MatchCollection SplitString(string sentence) => 
        Regex.Matches(sentence, @"\b\w+\b", RegexOptions.IgnoreCase);
}