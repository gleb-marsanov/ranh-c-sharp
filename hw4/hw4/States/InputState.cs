namespace hw4.States;

internal class InputState : IState
{
    private readonly ProgramStateMachine _stateMachine;

    public InputState(ProgramStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public async Task Enter()
    {
        Console.WriteLine("Введите число:");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int number))
        {
            await _stateMachine.Enter<CalculationState, int>(number);
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Нужно целое число.");
            await _stateMachine.Enter<InputState>();
        }
    }
}