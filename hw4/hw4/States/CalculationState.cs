namespace hw4.States;

public class CalculationState : IPayloadState<int>
{
    private readonly ProgramStateMachine _stateMachine;

    public CalculationState(ProgramStateMachine stateMachine) =>
        _stateMachine = stateMachine;

    public async Task Enter(int number)
    {
        bool isSimple = await CheckNumber(number);

        Console.WriteLine(isSimple
            ? $"Число {number} является простым."
            : $"Число {number} не является простым."
        );

        await _stateMachine.Enter<ExitState>();
    }

    private async Task<bool> CheckNumber(int number)
    {
        await Task.Yield();
        
        var counter = 2;
        
        while (counter < number)
        {
            if (number % counter == 0)
                return false;

            counter++;

            float progress = (float)counter / number * 100;
            Console.Write($"\rПрогресс: {Math.Round(progress, 3)}%\t\t");
        }

        Console.WriteLine();
        return true;
    }
}