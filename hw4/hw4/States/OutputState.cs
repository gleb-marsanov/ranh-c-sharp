namespace hw4.States;

public class OutputState : IPayloadState<bool>
{
    private readonly ProgramStateMachine _stateMachine;

    public OutputState(ProgramStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter(bool payload)
    {
        Console.WriteLine(payload ? "Чётное" : "Нечётное");
        _stateMachine.Enter<ExitState>();
    }
}