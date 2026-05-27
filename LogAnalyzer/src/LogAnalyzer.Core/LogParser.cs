using System;

namespace LogAnalyzer.Core
{
    /// <summary>
    /// Responsible for decomposing raw log strings into structured data models.
    /// </summary>
    public static class LogParser
    {
        /// <summary>
        /// Parses a single line from a standard access log into a LogEntry object.
        /// </summary>
        /// <param name="logLine">A single line of text from the log file.</param>
        /// <returns>A populated LogEntry, or null/throws if the line is invalid.</returns>
        /// <exception cref="FormatException">Thrown if the line does not match the expected log format.</exception>
        public static LogEntry ParseLine(string logLine)
        {
            if (string.IsNullOrWhiteSpace(logLine))
            {
                throw new ArgumentException("Log line cannot be null or empty.");
            }

            var entry = new LogEntry();

            // TODO: 1. Decide on your parsing strategy (Regex, String.Split, or ReadOnlySpan<char> for high performance).
            // TODO: 2. Extract the IP Address (usually the first token).
            // TODO: 3. Extract and parse the Timestamp into a standard C# DateTime object.
            // TODO: 4. Extract the HTTP Method and Path from inside the quotation marks (e.g., "GET /index.html HTTP/1.1").
            // TODO: 5. Extract the Status Code and parse it into an integer.
            // TODO: 6. Extract the Bytes sent and parse it into a long.

            throw new NotImplementedException("Implement log line parsing logic here.");
        }
    }
}
