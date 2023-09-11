namespace hw4.States;

public class ExitState : IState
{
    private readonly ProgramStateMachine _stateMachine;

    public ExitState(ProgramStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Console.WriteLine("Для выхода нажмите X или Esc, для ввода нового числа - любую другую клавишу.");

        ConsoleKeyInfo input = Console.ReadKey(true);

        Console.Clear();

        if (input.Key is ConsoleKey.X or ConsoleKey.Escape)
            Environment.Exit(0);
        else
            _stateMachine.Enter<InputState>();
        
        Environment.Exit(0);
    }
}