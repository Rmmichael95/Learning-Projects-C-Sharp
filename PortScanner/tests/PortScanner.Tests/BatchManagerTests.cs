using System.Collections.Generic;
using System.Threading.Tasks;
using PortScanner.Core;
using Xunit;

namespace PortScanner.Tests
{
    public class BatchManagerTests
    {
        [Fact]
        public async Task ProcessInBatches_LimitsConcurrentExecutions()
        {
            // Arrange: We will create 100 dummy tasks, but limit execution to 10 at a time.
            int maxConcurrency = 10;
            var activeTasks = 0;
            var maxActiveTasksObserved = 0;
            var lockObject = new object();

            // Act
            // TODO: Implement your BatchManager logic here or call it.
            // Simulate work that increments 'activeTasks', checks if it exceeds max,
            // records the peak, delays for 10ms, and then decrements 'activeTasks'.
            BatchManager bManager = new(maxConcurrency);

            List<Task> tasks = [];
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(
                    bManager.RunAsync(async () =>
                    {
                        lock (lockObject)
                        {
                            activeTasks++;
                            maxActiveTasksObserved =
                                activeTasks > maxActiveTasksObserved
                                    ? activeTasks
                                    : maxActiveTasksObserved;
                        }

                        await Task.Delay(10);

                        lock (lockObject)
                        {
                            activeTasks--;
                        }
                    })
                );
            }
            await Task.WhenAll(tasks);

            // Assert
            Assert.True(
                maxActiveTasksObserved <= maxConcurrency,
                "The batch manager allowed too many threads to execute at once!"
            );
        }
    }
}
