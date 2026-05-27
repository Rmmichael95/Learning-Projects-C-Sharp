using System;

namespace LogAnalyzer.Core
{
    /// <summary>
    /// Represents a strongly-typed model of a single server access log entry.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// The IP address of the client making the request.
        /// </summary>
        public string IpAddress { get; set; } = string.Empty;

        /// <summary>
        /// The exact date and time the request was logged.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The HTTP Method used (e.g., GET, POST).
        /// </summary>
        public string Method { get; set; } = string.Empty;

        /// <summary>
        /// The resource path requested (e.g., /images/logo.png).
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The HTTP status code returned by the server (e.g., 200, 404).
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The size of the response body in bytes.
        /// </summary>
        public long BytesSent { get; set; }
    }
}
