using System;
using System.Collections.Generic;

namespace HttpServer.Core
{
    /// <summary>
    /// Represents a parsed incoming HTTP request.
    /// </summary>
    public class HttpRequest
    {
        public string Method { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string HttpVersion { get; set; } = string.Empty;

        // Use StringComparer.OrdinalIgnoreCase because HTTP headers are case-insensitive by spec.
        public Dictionary<string, string> Headers { get; set; } =
            new(StringComparer.OrdinalIgnoreCase);

        public string Body { get; set; } = string.Empty;
    }
}
