namespace hw4.States;

public class ProgramStateMachine
{
    private readonly Dictionary<Type, IBaseState> _states;

    public ProgramStateMachine()
    {
        _states = new Dictionary<Type, IBaseState>
        {
            { typeof(InputState), new InputState(this) },
            { typeof(CalculationState), new CalculationState(this) },
            { typeof(ExitState), new ExitState(this) }
        };
    }

    public async Task Enter<TState>() where TState : IState
    {
        var state = _states[typeof(TState)] as IState;
        await state?.Enter()!;
    }

    public async Task Enter<TState, TValue>(TValue value) where TState : IPayloadState<TValue>
    {
        var state = _states[typeof(TState)] as IPayloadState<TValue>;
        await state?.Enter(value)!;
    }
}