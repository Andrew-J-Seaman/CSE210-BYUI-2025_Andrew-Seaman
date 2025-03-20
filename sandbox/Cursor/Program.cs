using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await PerformOperationAsync();
    }

    private static async Task PerformOperationAsync()
    {
        await LongRunningOperationAsync();
    }

    private static async Task LongRunningOperationAsync()
    {
        // Simulate a long-running task
        await Task.Delay(5000);
    }
}
