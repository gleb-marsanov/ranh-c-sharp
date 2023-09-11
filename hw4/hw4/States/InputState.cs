namespace hw4.States;

internal class InputState : IState
{
    private readonly ProgramStateMachine _stateMachine;

    public InputState(ProgramStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Console.WriteLine("Введите число:");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            _stateMachine.Enter<ParsingState, int>(number);
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Нужно целое число.");
            _stateMachine.Enter<InputState>();
        }
    }
}