namespace hw10;

internal static class ConsoleExtensions
{
    internal static int ReadInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine()!.Trim(), out int result))
            {
                return result;
            }

            WriteError("Введите целое число.");
        }
    }

    public static string ReadLine()
    {
        while (true)
        {
            string? fullName = Console.ReadLine();
            if (fullName != null && !string.IsNullOrEmpty(fullName))
                return fullName;

            WriteError("Строка не может быть пустой.");
        }
    }

    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static DateOnly ReadDate()
    {
        while (true)
        {
            if (DateOnly.TryParse(Console.ReadLine()!.Trim(), out DateOnly result))
                return result;

            WriteError("Введите дату в формате ДД.ММ.ГГГГ.");
        }
    }
}