using System.Text;
using hw4.States;
using hw4.Utils;

namespace hw4;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var deckParser = new DeckParser();
        var stateMachine = new ProgramStateMachine(deckParser);
        stateMachine.Enter<InputState>();
    }
}