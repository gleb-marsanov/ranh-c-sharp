using System.Text;
using hw10.Data;
using hw10.Factories;
using hw10.States;
using hw10.Utilities;

namespace hw10;

internal static class Program
{
    internal static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding(866);
        Console.InputEncoding = Encoding.GetEncoding(866);

        var stringSerializer = new StringSerializer();
        var dataService = new Repository(stringSerializer);
        var workerFactory = new RandomWorkerFactory(dataService);
        var stateMachine = new ProgramStateMachine(dataService, workerFactory);

        stateMachine.Enter<ModeSelectionState>();
    }
}