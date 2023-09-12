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

        var firstMatrix = new int[rows, columns];
        var secondMatrix = new int[rows, columns];

        var random = new Random();
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                firstMatrix[i, j] = random.Next(0, 100);
                secondMatrix[i, j] = random.Next(0, 100);
            }
        }

        Console.WriteLine($"Матрица 1: \n{firstMatrix.ToStringTable()}");
        Console.WriteLine($"Матрица 2: \n{secondMatrix.ToStringTable()}");

        var sumMatrix = new int[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                sumMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
        }

        Console.WriteLine($"Сумма матриц: \n{sumMatrix.ToStringTable()}");
    }
}