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
        
        string reversedSentence = ReverceSentence(sentence);
        Console.WriteLine(reversedSentence);
    }

    private static string ReverceSentence(string sentence) => 
        string.Join(' ', SplitString(sentence).Reverse());

    private static IEnumerable<string> SplitString(string sentence) =>
        sentence.Split(' ');
}