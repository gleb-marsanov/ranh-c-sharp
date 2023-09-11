namespace hw4.States;

internal class InputState : IState
{
    private readonly ProgramStateMachine _stateMachine;
    private readonly NumberParser _numberParser;

    public InputState(ProgramStateMachine stateMachine, NumberParser numberParser)
    {
        _stateMachine = stateMachine;
        _numberParser = numberParser;
    }

    public void Enter()
    {
        Console.WriteLine("Сколько чисел в последовательности:");

        string? input = Console.ReadLine();

        if (int.TryParse(input?.Trim(), out int count))
        {
            var sequence = new int[count];
            for (var i = 0; i < count; i++)
            {
                sequence[i] = _numberParser.ReadNumber();
            }

            _stateMachine.Enter<SearchState, int[]>(sequence);
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Нужно целое число.");
            _stateMachine.Enter<InputState>();
        }
    }
}