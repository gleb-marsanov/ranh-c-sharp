using System.Text;
using hw4.States;

namespace hw4;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        var stateMachine = new ProgramStateMachine();
        stateMachine.Enter<InputState>();
    }
}