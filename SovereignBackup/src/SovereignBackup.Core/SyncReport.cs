using System.Collections.Concurrent;

namespace SovereignBackup.Core
{
    /// <summary>
    /// A thread-safe data model tracking the results of a concurrent backup operation.
    /// </summary>
    public class SyncReport
    {
        // Using ConcurrentBag because multiple threads will be adding to these simultaneously
        public ConcurrentBag<string> CopiedFiles { get; } = new();
        public ConcurrentBag<string> SkippedFiles { get; } = new();
        public ConcurrentBag<string> FailedFiles { get; } = new();

        public int TotalProcessed => CopiedFiles.Count + SkippedFiles.Count + FailedFiles.Count;
    }
}
