namespace hw4.States;

public class CalculationState : IPayloadState<int[]>
{
    private readonly ProgramStateMachine _stateMachine;

    public CalculationState(ProgramStateMachine stateMachine) => 
        _stateMachine = stateMachine;

    public void Enter(int[] cards)
    {
        ConsoleColor initColor = Console.ForegroundColor;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Сумма ваших карт: {cards.Sum()}");
        Console.ForegroundColor = initColor;
        
        _stateMachine.Enter<ExitState>();
    }
}