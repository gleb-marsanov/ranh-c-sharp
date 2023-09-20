using hw10.Data;
using hw10.Extensions;
using hw10.Factories;

namespace hw10.States;

internal class DataEntryState : IState
{
    private readonly Repository _repository;
    private readonly WorkerFactory _workerFactory;
    private readonly ProgramStateMachine _stateMachine;

    public DataEntryState(Repository repository, WorkerFactory workerFactory, ProgramStateMachine stateMachine)
    {
        _repository = repository;
        _workerFactory = workerFactory;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Console.WriteLine("1. Добавить запись" +
                          "\n2. Удалить запись");

        switch (ConsoleExtensions.ReadInt())
        {
            case 1:
                AddRecord();
                break;
            case 2:
                DeleteRecord();
                break;
        }
        
        _stateMachine.Enter<ModeSelectionState>();
    }

    private void DeleteRecord()
    {
        Console.WriteLine("Введите ID записи: ");
        int id = ConsoleExtensions.ReadInt();
        
        _repository.RemoveWorker(id);
    }

    private void AddRecord()
    {
        _workerFactory.CreateWorker();
    }
}