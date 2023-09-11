namespace hw4.States;

public class CalculationState : IPayloadState<int>
{
    private readonly ProgramStateMachine _stateMachine;

    public CalculationState(ProgramStateMachine stateMachine) =>
        _stateMachine = stateMachine;

    public void Enter(int number)
    {
        var counter = 2;
        var isSimple = true;
        
        while (counter < number)
        {
            if (number % counter == 0)
            {
                Console.WriteLine();
                isSimple = false;
                break;
            }

            counter++;
        }

        Console.WriteLine(isSimple
            ? $"Число {number} является простым."
            : $"Число {number} не является простым."
        );
        
        _stateMachine.Enter<ExitState>();
    }
}