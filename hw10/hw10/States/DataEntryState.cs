using hw10.Data;
using hw10.Factories;
using hw10.Utilities;

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
        _workerFactory.CreateWorker();
        _stateMachine.Enter<ModeSelectionState>();
    }
}