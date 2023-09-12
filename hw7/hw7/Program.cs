using System.Text;

namespace hw7;

internal static class Program
{
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding(866);
        Console.InputEncoding = Encoding.GetEncoding(866);

        Console.WriteLine("Введите предложение: ");
        string sentence = Console.ReadLine()!;

        IEnumerable<string> words = SplitString(sentence);
        WriteWordsToConsole(words);
    }

    private static void WriteWordsToConsole(IEnumerable<string> words) =>
        Console.WriteLine(string.Join('\n', words));

    private static IEnumerable<string> SplitString(string sentence) => 
        sentence.Split(' ');
}