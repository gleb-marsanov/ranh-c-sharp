namespace hw4;

public class NumberParser
{
    public int ReadNumber()
    {
        Console.WriteLine("Введите число:");

        string? input = Console.ReadLine();

        if (int.TryParse(input?.Trim(), out int number))
        {
            return number;
        }

        Console.WriteLine("Некорректный ввод. Нужно целое число.");
        return ReadNumber();
    }
}