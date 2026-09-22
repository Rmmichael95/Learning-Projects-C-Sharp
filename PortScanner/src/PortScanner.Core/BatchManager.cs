using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner.Core
{
    /// <summary>
    /// Controls the flow of asynchronous tasks to prevent socket exhaustion.
    /// </summary>
    public class BatchManager(int maxConnections)
    {
        // TODO: Look up how 'SemaphoreSlim' works in C#. It acts as a bouncer
        // for your async tasks, only letting 'X' amount run concurrently.
        private readonly SemaphoreSlim _semaphore = new(
            initialCount: maxConnections,
            maxCount: maxConnections
        );

        public async Task RunAsync(Func<Task> asyncTask)
        {
            await _semaphore.WaitAsync();
            try
            {
                // Task runningTask = asyncTask();
                // await runningTask;
                await asyncTask();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
