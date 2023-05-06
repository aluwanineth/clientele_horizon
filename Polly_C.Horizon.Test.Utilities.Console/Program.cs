using Utils = Polly_C.Horizon.Utilities;

namespace Polly_C.Horizon.Test.Utilities.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine( Utils.DataStructureToJSONSchema.GetMessagePolicyV1Schema());
        }
    }
}