using System;
using System.Globalization;

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
            ReadOnlySpan<char> span = logLine.AsSpan();

            // IP Address
            int delimiter = span.IndexOf(' ');

            if (delimiter == -1)
            {
                throw new FormatException("Malformed IP.");
            }

            ReadOnlySpan<char> subSpan = span[..delimiter];
            entry.IpAddress = subSpan.ToString();

            span = span[(delimiter + 1)..];

            // Timestamp
            if (span.IndexOf('[') == -1 || span.IndexOf(']') == -1)
            {
                throw new FormatException("Missing timestamp open/closing bracket.");
            }

            delimiter = span.IndexOf('[') + 1;
            subSpan = span[delimiter..span.IndexOf(']')];

            if (subSpan.IndexOf(' ') == -1)
            {
                throw new FormatException("Missing timestamp UTC offset.");
            }

            entry.Timestamp = DateTime.ParseExact(
                subSpan[..subSpan.IndexOf(' ')],
                "dd/MMM/yyyy:HH:mm:ss",
                CultureInfo.InvariantCulture
            );

            // HTTP Method
            if (span.IndexOf('"') == -1 || span.IndexOf(' ') == -1)
            {
                throw new FormatException("Incorrect Method formatting.");
            }

            span = span[span.IndexOf('"')..];

            delimiter = span.IndexOf(' ');

            if (delimiter == -1)
            {
                throw new FormatException("Incorrect Method formatting.");
            }

            subSpan = span[1..delimiter];
            entry.Method = subSpan.ToString();

            // Path
            span = span[(delimiter + 1)..];
            delimiter = span.IndexOf(' ');

            if (delimiter == -1)
            {
                throw new FormatException("Incorrect Path formatting.");
            }

            entry.Path = span[..delimiter].ToString();

            // Status Code
            delimiter = span.IndexOf('"');

            if (delimiter == -1)
            {
                throw new FormatException("Incorrect status code formatting.");
            }

            span = span[(delimiter + 2)..];

            if (span.IndexOf(' ') == -1)
            {
                throw new FormatException("Incorrect status code formatting.");
            }

            subSpan = span[..span.IndexOf(' ')];
            entry.StatusCode = Convert.ToInt32(subSpan.ToString());

            // Bytes Sent
            delimiter = span.IndexOf(' ');

            if (delimiter == -1)
            {
                throw new FormatException("Incorrect bytes formatting.");
            }

            span = span[(delimiter + 1)..];

            if (span.IndexOf(' ') == -1)
            {
                throw new FormatException("Incorrect bytes formatting.");
            }

            entry.BytesSent = Convert.ToInt64(span[..span.IndexOf(' ')].ToString());

            return entry;
        }
    }
}
