namespace ConsoleApp;

internal record StudentData(string FullName, int Age, string Email, float ProgrammingScore, float MathScore, float PhysicsScore)
{
    public override string ToString() => 
        string.Join("\t", FullName, Age, Email, ProgrammingScore, MathScore, PhysicsScore);
}