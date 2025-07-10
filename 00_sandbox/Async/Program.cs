using System;
using System.Threading.Tasks;

namespace Sandbox2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PerformOperationAsync();
        }

        private static async Task PerformOperationAsync()
        {
            ShowSpinner();
            await LongRunningOperationAsync();
            HideSpinner();
        }

        private static void ShowSpinner()
        {
            // Implement your spinner display logic here
            Console.CursorVisible = false;
        }

        private static void HideSpinner()
        {
            // Implement your spinner hide logic here
            Console.CursorVisible = true;
        }

        private static async Task LongRunningOperationAsync()
        {
            // Simulate a long-running task
            await Task.Delay(5000);
        }
    }
}