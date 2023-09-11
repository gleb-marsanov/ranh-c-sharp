namespace hw4.States;

public class ProgramStateMachine
{
    private readonly Dictionary<Type, IBaseState> _states;

    public ProgramStateMachine()
    {
        _states = new Dictionary<Type, IBaseState>
        {
            { typeof(InputState), new InputState(this) },
            { typeof(ParsingState), new ParsingState(this) },
            { typeof(OutputState), new OutputState(this) },
            { typeof(ExitState), new ExitState(this) }
        };
    }

    public void Enter<TState>() where TState : IState
    {
        var state = _states[typeof(TState)] as IState;
        state?.Enter();
    }

    public void Enter<TState, TValue>(TValue value) where TState : IPayloadState<TValue>
    {
        var state = _states[typeof(TState)] as IPayloadState<TValue>;
        state?.Enter(value);
    }
}