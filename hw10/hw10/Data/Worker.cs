namespace hw10.Data;

internal class Worker
{
    public int Id { get; init; }
    public string FullName { get; init; } = null!;
    public DateTime CreationDate { get; init; }
    public int Age { get; init; }
    public int Height { get; init; }
    public DateOnly BirthDate { get; init; }
    public string BirthPlace { get; init; } = null!;

    public override string ToString() =>
        $"{Id} {FullName} {CreationDate:dd.MM.yyyy hh:mm} {Age} {Height} {BirthDate:dd.MM.yyyy} {BirthPlace}";
}