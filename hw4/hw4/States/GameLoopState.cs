namespace hw4.States;

public class GameLoopState : IPayloadState<int>
{
    private readonly ProgramStateMachine _stateMachine;

    public GameLoopState(ProgramStateMachine stateMachine) =>
        _stateMachine = stateMachine;

    public void Enter(int maxNumber)
    {
        int targetNumber = new Random().Next(1, maxNumber + 1);
        
        while (true)
        {
            Console.WriteLine("Введите число:");

            string input = Console.ReadLine()?.Trim()!;

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"Очень жаль, я загадал {targetNumber}");
                _stateMachine.Enter<ExitState>();
                return;
            }

            if (int.TryParse(input, out int number))
            {
                if (number == targetNumber)
                {
                    Console.WriteLine($"Вы угадали! Я загадал {targetNumber}");
                    _stateMachine.Enter<ExitState>();
                    return;
                }

                Console.WriteLine(number < targetNumber
                    ? $"Загаданное число больше чем {input}"
                    : $"Загаданное число меньше чем {input}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Нужно целое число или пустая строка для выхода.");
            }
        }
    }
}