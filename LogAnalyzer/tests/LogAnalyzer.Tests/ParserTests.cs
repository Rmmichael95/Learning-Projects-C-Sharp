using System;
using LogAnalyzer.Core;
using Xunit;

namespace LogAnalyzer.Tests
{
    public class ParserTests
    {
        [Fact]
        public void ParseLine_ValidNginxCombinedLog_ExtractsAllFields()
        {
            // Arrange: A standard Nginx/Apache log format
            string rawLine =
                "192.168.1.50 - - [10/Oct/2026:13:55:36 -0700] \"GET /api/data HTTP/1.1\" 200 5120 \"-\" \"Mozilla/5.0\"";

            // Act
            LogEntry entry = LogParser.ParseLine(rawLine);

            // Assert
            Assert.NotNull(entry);
            Assert.Equal("192.168.1.50", entry.IpAddress);
            Assert.Equal("GET", entry.Method);
            Assert.Equal("/api/data", entry.Path);
            Assert.Equal(200, entry.StatusCode);
            Assert.Equal(5120, entry.BytesSent);
            Assert.Equal(new DateTime(2026, 10, 10, 13, 55, 36), entry.Timestamp);
            // Hint for the timestamp: You may need DateTime.ParseExact with a custom format string
        }

        [Fact]
        public void ParseLine_InvalidNginxCombinedLog_ThrowsFormatException()
        {
            // Arrange: A standard Nginx/Apache log format
            string rawLine =
                "192.168.1.50 - - [10/Oct/2026:13:55:36 -0700 \"GET /api/data HTTP/1.1\" 200 5120 \"-\" \"Mozilla/5.0\"";

            // Assert
            Assert.Throws<FormatException>(() => LogParser.ParseLine(rawLine));
        }

        [Fact]
        public void Metrics_GetTopIpAddresses_ReturnsCorrectCounts()
        {
            // Arrange: Seed the calculator with mock data directly in memory
            var mockEntries = new[]
            {
                new LogEntry { IpAddress = "10.0.0.1" },
                new LogEntry { IpAddress = "10.0.0.1" },
                new LogEntry { IpAddress = "192.168.0.5" },
                new LogEntry { IpAddress = "10.0.0.1" },
                new LogEntry { IpAddress = "192.168.0.5" },
                new LogEntry { IpAddress = "172.16.0.1" },
            };

            var calculator = new MetricsCalculator(mockEntries);

            // Act
            var topIps = calculator.GetTopIpAddresses(2);

            // Assert
            Assert.Equal(2, topIps.Count);
            Assert.Equal(3, topIps["10.0.0.1"]);
            Assert.Equal(2, topIps["192.168.0.5"]);
            Assert.False(topIps.ContainsKey("172.16.0.1"));
        }

        [Fact]
        public void Metrics_GetTotalRequestsByStatusCode_ReturnsCorrectCount()
        {
            // Arrange: Seed the calculator with mock data directly in memory
            var mockEntries = new[]
            {
                new LogEntry { StatusCode = 200 },
                new LogEntry { StatusCode = 404 },
                new LogEntry { StatusCode = 200 },
                new LogEntry { StatusCode = 500 },
                new LogEntry { StatusCode = 404 },
                new LogEntry { StatusCode = 404 },
            };

            var calculator = new MetricsCalculator(mockEntries);

            // Act
            var totalRequests = calculator.GetTotalRequestsByStatusCode(404);

            // Assert
            Assert.Equal(3, totalRequests);
        }

        [Fact]
        public void Metrics_GetTotalBytesTransferred_ReturnsCorrectTotal()
        {
            // Arrange: Seed the calculator with mock data directly in memory
            var mockEntries = new[]
            {
                new LogEntry { BytesSent = 1000 },
                new LogEntry { BytesSent = 2500 },
                new LogEntry { BytesSent = 500 },
                new LogEntry { BytesSent = 6000 },
            };

            var calculator = new MetricsCalculator(mockEntries);

            // Act
            var totalBytes = calculator.GetTotalBytesTransferred();

            // Assert
            Assert.Equal(10000, totalBytes);
        }
    }
}
