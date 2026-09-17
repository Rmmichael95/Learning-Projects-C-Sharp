using System.Collections.Generic;

namespace LogAnalyzer.Core
{
    /// <summary>
    /// Computes statistical aggregations over a collection of parsed log entries.
    /// </summary>
    public class MetricsCalculator
    {
        private readonly IEnumerable<LogEntry> _entries;

        public MetricsCalculator(IEnumerable<LogEntry> entries)
        {
            _entries = entries;
        }

        /// <summary>
        /// Identifies the IP addresses that made the most requests.
        /// </summary>
        /// <param name="limit">The number of top IPs to return.</param>
        /// <returns>A dictionary mapping IP addresses to their total request count.</returns>
        public Dictionary<string, int> GetTopIpAddresses(int limit = 5)
        {
            // TODO: Group the _entries by IpAddress, count them, sort descending, and take the top 'limit'.
            // Dictionary<string, int> result = [];
            // foreach (var entry in _entries)
            // {
            //     if (result.TryGetValue(entry.IpAddress, out var count))
            //         result[entry.IpAddress] = count + 1;
            //     else
            //         result.Add(entry.IpAddress, 1);
            // }
            // return result.OrderByDescending(entry => entry.Value).Take(limit).ToDictionary();

            // return _entries
            //     .GroupBy(entry => entry.IpAddress)
            //     .Select(group => new { IpAddress = group.Key, Count = group.Count() })
            //     .OrderByDescending(entry => entry.Count)
            //     .Take(limit)
            //     .ToDictionary(group => group.IpAddress, group => group.Count);

            return _entries
                .GroupBy(
                    entry => entry.IpAddress,
                    (ipAddress, entries) => new { IpAddress = ipAddress, Count = entries.Count() }
                )
                .OrderByDescending(entry => entry.Count)
                .Take(limit)
                .ToDictionary(group => group.IpAddress, group => group.Count);
        }

        /// <summary>
        /// Calculates the total number of specific status codes (e.g., counting all 404s or 500s).
        /// </summary>
        public int GetTotalRequestsByStatusCode(int statusCode)
        {
            // TODO: Filter the _entries where StatusCode matches the target, and return the count.
            return _entries.Count(entry => entry.StatusCode == statusCode);
        }

        /// <summary>
        /// Calculates the total bandwidth consumed across all parsed requests.
        /// </summary>
        public long GetTotalBytesTransferred()
        {
            // TODO: Sum the BytesSent property across all entries.
            return _entries.Sum(entry => entry.BytesSent);
        }
    }
}
