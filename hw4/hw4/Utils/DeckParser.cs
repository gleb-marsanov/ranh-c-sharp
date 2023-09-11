namespace hw4.Utils;

public class DeckParser
{
    private readonly Dictionary<string, int> _images = new Dictionary<string, int>()
    {
        { "j", 11 },
        { "q", 12 },
        { "k", 13 },
        { "t", 14 }
    };

    public int ParseCard()
    {
        string input = Console.ReadLine()!;
        
        if (int.TryParse(input, out int card) && card is >= 2 and <= 10)
            return card;

        if (_images.ContainsKey(input.ToLower()))
            return _images[input];

        Console.WriteLine("Некорректный ввод. Нужно целое число от 2 до 10 или j, q, k, t.");
        return ParseCard();
    }
}