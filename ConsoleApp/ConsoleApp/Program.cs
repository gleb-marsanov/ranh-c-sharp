namespace ConsoleApp;

public static class Program
{
    public static void Main()
    {
        var outputData = new StudentDataList()
        {
            new StudentData("John Doe", 18, "john-doe@gmail.com", 4.5f, 3.3f, 4.7f),
            new StudentData("Alisa Banana", 19, "alisa-banana@gmail.com", 4.6f, 4.3f, 4.1f),
            new StudentData("Bob Marley", 20, "bob-marley@gmail.com", 4.7f, 4.2f, 4.3f),
            new StudentData("Cindy Crawford", 21, "cindy-crawford@gmail.com", 4.8f, 4.1f, 4.5f),
        };

        IEnumerable<string> averageData = outputData.Select(x=>$"{x.FullName}\t{Math.Round(x.AverageScore, 2)}");
        foreach (string studentDataOutput in averageData)
        {
            Console.WriteLine(studentDataOutput);
            Console.ReadKey();
        }
    }
}