using System.Text;

namespace hw6.Extensions;

public static class ArrayExtensions
{
    public static string ToStringTable(this int[,] intArray)
    {
        int rows = intArray.GetLength(0);
        int columns = intArray.GetLength(1);
        var sb = new StringBuilder();
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                sb.Append($"{intArray[i, j],4}");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}