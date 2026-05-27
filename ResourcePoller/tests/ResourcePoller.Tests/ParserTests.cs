using ResourcePoller.Core;
using Xunit;

namespace ResourcePoller.Tests
{
    public class ParserTests
    {
        [Fact]
        public void ParseMemInfo_ValidProcData_ExtractsCorrectValues()
        {
            // Arrange: A mock snippet of what a Linux kernel outputs
            string mockProcMeminfo =
                "MemTotal:       16275860 kB\n"
                + "MemFree:         4871232 kB\n"
                + "MemAvailable:   10123456 kB\n"
                + "Buffers:          213456 kB\n";

            // Act
            var metrics = ProcfsParser.ParseMemInfo(mockProcMeminfo);

            // Assert
            Assert.Equal(16275860, metrics.TotalMemoryKb);
            Assert.Equal(4871232, metrics.FreeMemoryKb);
            Assert.Equal(10123456, metrics.AvailableMemoryKb);
            Assert.True(metrics.MemoryUsagePercentage > 0);
        }
    }
}
