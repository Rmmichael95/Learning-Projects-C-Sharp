using System;

namespace ResourcePoller.Core
{
    /// <summary>
    /// Pure string parsing logic isolated from the actual file system.
    /// </summary>
    public static class ProcfsParser
    {
        public static SystemMetrics ParseMemInfo(string memInfoContent)
        {
            var metrics = new SystemMetrics();

            // TODO: 1. Split the incoming massive string by newline characters.
            // TODO: 2. Loop through the lines.
            // TODO: 3. If line starts with "MemTotal:", extract the number, parse to long, assign to metrics.TotalMemoryKb.
            // TODO: 4. Repeat for "MemFree:" and "MemAvailable:".
            // TODO: 5. Return the populated metrics object.

            throw new NotImplementedException();
        }
    }
}
