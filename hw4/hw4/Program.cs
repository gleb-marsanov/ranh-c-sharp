using System.Text;
using hw4.States;

namespace hw4;

public static class Program
{
    public static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var stateMachine = new ProgramStateMachine();
        await stateMachine.Enter<InputState>();
    }
}