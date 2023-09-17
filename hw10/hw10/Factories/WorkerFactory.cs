using hw10.Data;

namespace hw10.Factories;

internal class WorkerFactory
{
    protected readonly Repository Repository;

    public WorkerFactory(Repository repository)
    {
        Repository = repository;
    }

    public virtual Worker CreateWorker()
    {
        var worker = new Worker
        {
            Id = GetUniqueId(),
            FullName = ReadFullName(),
            CreationDate = DateTime.Now,
            Age = ReadAge(),
            Height = ReadHeight(),
            BirthDate = ReadBirthDate(),
            BirthPlace = ReadBithPlace()
        };
        
        Repository.AddWorker(worker);
        
        return worker;
    }

    protected int GetUniqueId() =>
        Repository.Workers.Any() ? Repository.Workers.Max(x => x.Id) + 1 : 0;

    private string ReadFullName()
    {
        Console.WriteLine("ФИО: ");
        return ConsoleExtensions.ReadLine();
    }

    private int ReadAge()
    {
        Console.WriteLine("Возраст: ");
        return ConsoleExtensions.ReadInt();
    }

    private int ReadHeight()
    {
        Console.WriteLine("Рост: ");
        return ConsoleExtensions.ReadInt();
    }

    private DateOnly ReadBirthDate()
    {
        Console.WriteLine("Дата рождения: ");
        return ConsoleExtensions.ReadDate();
    }

    private string ReadBithPlace()
    {
        Console.WriteLine("Место рождения: ");
        return ConsoleExtensions.ReadLine();
    }
}