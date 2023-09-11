namespace ConsoleApp;

internal class StudentDataList : List<StudentData>
{
    public override string ToString() => 
        string.Join("\n", this.Select(x=>x.ToString()));
}