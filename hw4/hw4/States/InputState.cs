using hw4.Utils;

namespace hw4.States;

internal class InputState : IState
{
    private readonly ProgramStateMachine _stateMachine;
    private readonly DeckParser _deckParser;

    public InputState(ProgramStateMachine stateMachine, DeckParser deckParser)
    {
        _stateMachine = stateMachine;
        _deckParser = deckParser;
    }

    public void Enter()
    {
        Console.WriteLine("Здравствуйте! Сколько у вас карт?");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int cardCount))
        {
            var cards = new int[cardCount];
            for (var i = 0; i < cardCount; i++)
            {
                Console.WriteLine(i > 0 ? "Введите номинал следующей карты:" : "Введите номинал первой карты:");
                cards[i] = _deckParser.ParseCard();
            }

            _stateMachine.Enter<CalculationState, int[]>(cards);
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Нужно целое число.");
            _stateMachine.Enter<InputState>();
        }
    }
}