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

    public bool TryGetWorker(int id, out Worker? worker)
    {
        worker = _workers.FirstOrDefault(x => x.Id == id);

        return worker is not null;
    }

    public void RemoveWorker(int id)
    {
        _workers.RemoveAll(x => x.Id == id);
        Save();
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        using var writer = new StreamWriter(_dataFilePath, true);
        string strData = _stringSerializer.Serialize(worker);
        writer.WriteLine(strData);
    }

    public IEnumerable<Worker> GetWorkersCreatedBetween(DateOnly start, DateOnly end) => 
        _workers.Where(x => DateOnly.FromDateTime(x.CreationDate) >= start && DateOnly.FromDateTime(x.CreationDate.Date) <= end);

    private IEnumerable<Worker> LoadAllWorkers()
    {
        using var reader = new StreamReader(_dataFilePath);
        while (reader.ReadLine() is { } line)
            yield return _stringSerializer.Deserialize<Worker>(line);
    }

    private void Save()
    {
        File.WriteAllText(_dataFilePath, string.Empty);
        
        using var writer = new StreamWriter(_dataFilePath);
        foreach (string data in _workers.Select(worker => _stringSerializer.Serialize(worker)))
        {
            writer.WriteLine(data);
        }
    }
}