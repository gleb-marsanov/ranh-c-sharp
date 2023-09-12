using System.Text;
using hw6.Extensions;

namespace hw6;

internal static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Кол-во строк: ");
        int rows = ConsoleExtensions.ReadInt();

        Console.Write("Кол-во столбцов: ");
        int columns = ConsoleExtensions.ReadInt();

        var matrixWithRandomNumbers = new int[rows, columns];

        var random = new Random();
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                matrixWithRandomNumbers[i, j] = random.Next(0, 100);
        }

        Console.WriteLine("Матрица:");
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                Console.Write($"{matrixWithRandomNumbers[i, j],4}");
            Console.WriteLine();
        }

        int sum = matrixWithRandomNumbers.Cast<int>().Sum();
        Console.WriteLine($"Сумма всех элементов матрицы: {sum}");
    }
}