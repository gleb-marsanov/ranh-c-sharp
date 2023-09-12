namespace hw6.Extensions;

public static class ConsoleExtensions
{
    public static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine()!.Trim(), out int number))
                return number;

            Console.WriteLine("Введите число");
        }
    }
}