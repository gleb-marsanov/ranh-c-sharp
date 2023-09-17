using hw10.Utilities;

namespace hw10.Data;

internal class Repository
{
    private readonly string _dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data.txt");

    private readonly StringSerializer _stringSerializer;

    private readonly List<Worker> _workers;
    public IEnumerable<Worker> Workers => _workers;

    public Repository(StringSerializer stringSerializer)
    {
        _stringSerializer = stringSerializer;
        if (!File.Exists(_dataFilePath))
            File.Create(_dataFilePath).Close();

        _workers = LoadAllWorkers().ToList();
    }

    private IEnumerable<Worker> LoadAllWorkers()
    {
        using var reader = new StreamReader(_dataFilePath);
        while (reader.ReadLine() is { } line)
            yield return _stringSerializer.Deserialize<Worker>(line);
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        using var writer = new StreamWriter(_dataFilePath, true);
        string strData = _stringSerializer.Serialize(worker);
        writer.WriteLine(strData);
    }
}