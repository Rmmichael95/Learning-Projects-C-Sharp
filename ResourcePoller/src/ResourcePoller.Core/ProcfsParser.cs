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
            SystemMetrics metrics = new();

            // TODO: 1. Split the incoming massive string by newline characters.
            // TODO: 2. Loop through the lines.
            // TODO: 3. If line starts with "MemTotal:", extract the number, parse to long, assign to metrics.TotalMemoryKb.
            // TODO: 4. Repeat for "MemFree:" and "MemAvailable:".
            // TODO: 5. Return the populated metrics object.
            string[] lines = memInfoContent.Split('\n');

            foreach (string line in lines)
            {
                if (line.StartsWith("MemTotal:"))
                {
                    metrics.TotalMemoryKb = Convert.ToInt64(
                        line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                    );
                }
                else if (line.StartsWith("MemFree:"))
                {
                    metrics.FreeMemoryKb = Convert.ToInt64(
                        line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                    );
                }
                else if (line.StartsWith("MemAvailable:"))
                {
                    metrics.AvailableMemoryKb = Convert.ToInt64(
                        line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]
                    );
                }
            }
            return metrics;
        }
    }
}
