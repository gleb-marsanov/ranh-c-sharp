using hw10.Data;

namespace hw10.States;

internal class DataViewState : IState
{
    private readonly Repository _repository;
    private readonly ProgramStateMachine _stateMachine;

    public DataViewState(Repository repository, ProgramStateMachine stateMachine)
    {
        _repository = repository;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        WriteDataTableToConsole();
        _stateMachine.Enter<ModeSelectionState>();
    }

    private void WriteDataTableToConsole()
    {
        if (!_repository.Workers.Any())
            return;

        const string idColumn = "ID";
        const string creationDateColumn = "Creation Date";
        const string fullNameColumn = "Full Name";
        const string ageColumn = "Age";
        const string heightColumn = "Height";
        const string dateColumn = "Birth Date";
        const string birthPlaceColumn = "Birth Place";

        int idColumnWidth = Math.Max(_repository.Workers.Max(x => x.Id).ToString().Length, idColumn.Length);
        int creationDateColumnWidth = Math.Max(_repository.Workers.Max(x => x.CreationDate.ToString("dd.MM.yyyy hh:mm").Length), creationDateColumn.Length);
        int fullNameColumnWidth = Math.Max(_repository.Workers.Max(x => x.FullName.Length), fullNameColumn.Length);
        int ageColumnWidth = Math.Max(_repository.Workers.Max(x => x.Age.ToString().Length), ageColumn.Length);
        int heightColumnWidth = Math.Max(_repository.Workers.Max(x => x.Height.ToString().Length), heightColumn.Length);
        int birthDateColumnWidth = Math.Max(_repository.Workers.Max(x => x.BirthDate.ToString().Length), dateColumn.Length);
        int birthPlaceColumnWidth = Math.Max(_repository.Workers.Max(x => x.BirthPlace.Length), birthPlaceColumn.Length);

        Console.WriteLine(string.Join(" | ",
            idColumn.PadRight(idColumnWidth),
            creationDateColumn.PadRight(creationDateColumnWidth),
            fullNameColumn.PadRight(fullNameColumnWidth),
            ageColumn.PadRight(ageColumnWidth),
            heightColumn.PadRight(heightColumnWidth),
            dateColumn.PadRight(birthDateColumnWidth),
            birthPlaceColumn.PadRight(birthPlaceColumnWidth)
        ));

        foreach (Worker repositoryWorker in _repository.Workers)
        {
            Console.WriteLine(string.Join(" | ",
                repositoryWorker.Id.ToString().PadRight(idColumnWidth),
                repositoryWorker.CreationDate.ToString("dd.MM.yyyy hh:mm").PadRight(creationDateColumnWidth),
                repositoryWorker.FullName.PadRight(fullNameColumnWidth),
                repositoryWorker.Age.ToString().PadRight(ageColumnWidth),
                repositoryWorker.Height.ToString().PadRight(heightColumnWidth),
                repositoryWorker.BirthDate.ToString("dd.MM.yyyy").PadRight(birthDateColumnWidth),
                repositoryWorker.BirthPlace.PadRight(birthPlaceColumnWidth))
            );
        }
    }
}