namespace ResourcePoller.Core
{
    public class SystemMetrics
    {
        public long TotalMemoryKb { get; set; }
        public long FreeMemoryKb { get; set; }
        public long AvailableMemoryKb { get; set; }

        // Calculated property for easy UI display
        public double MemoryUsagePercentage =>
            TotalMemoryKb == 0
                ? 0
                : (double)(TotalMemoryKb - AvailableMemoryKb) / TotalMemoryKb * 100;
    }
}
