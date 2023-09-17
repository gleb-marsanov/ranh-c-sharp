using hw10.Data;

namespace hw10.Factories;

internal class RandomWorkerFactory : WorkerFactory
{
    private readonly string[] _names = new[]
    {
        "John", "James", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas", "Christopher",
        "Daniel", "Paul", "Mark", "Donald", "George", "Kenneth", "Steven", "Edward", "Brian"
    };

    private readonly string[] _surnames = new[]
    {
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez",
        "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White"
    };

    private readonly string[] _cities = new[]
    {
        "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware",
        "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky",
    };

    public RandomWorkerFactory(Repository repository) : base(repository)
    {
    }

    public override Worker CreateWorker()
    {
        var random = new Random();
        int age = random.Next(0, 100);
        var worker = new Worker
        {
            Id = GetUniqueId(),
            FullName = _names[random.Next(0, _names.Length)] + " " + _surnames[random.Next(0, _surnames.Length)],
            CreationDate = DateTime.Now,
            Age = age,
            Height = random.Next(50, 250),
            BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-age)),
            BirthPlace = _cities[random.Next(0, _cities.Length)]
        };
        
        Repository.AddWorker(worker);
        
        return worker;
    }
}