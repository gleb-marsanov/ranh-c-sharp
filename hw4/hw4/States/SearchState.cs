namespace hw4.States;

public class SearchState : IPayloadState<int[]>
{
    private readonly ProgramStateMachine _stateMachine;

    public SearchState(ProgramStateMachine stateMachine) =>
        _stateMachine = stateMachine;

    public void Enter(int[] number)
    {
        int min = number.Prepend(int.MaxValue).Min();
        Console.WriteLine($"Минимальное число: {min}");
        
        _stateMachine.Enter<ExitState>();
    }
}