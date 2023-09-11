namespace hw4.States;

public class ParsingState : IPayloadState<int>
{
    private readonly ProgramStateMachine _stateMachine;

    public ParsingState(ProgramStateMachine stateMachine) => 
        _stateMachine = stateMachine;

    public void Enter(int number) => 
        _stateMachine.Enter<OutputState, bool>(number % 2 == 0);
}