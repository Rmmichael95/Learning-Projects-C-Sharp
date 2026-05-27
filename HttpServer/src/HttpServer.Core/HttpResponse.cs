using System.Collections.Generic;
using System.Text;

namespace HttpServer.Core
{
    /// <summary>
    /// Represents an outgoing HTTP response and handles its conversion to network bytes.
    /// </summary>
    public class HttpResponse
    {
        public int StatusCode { get; set; } = 200;
        public string StatusMessage { get; set; } = "OK";
        public Dictionary<string, string> Headers { get; set; } =
            new(StringComparer.OrdinalIgnoreCase);
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// Serializes the object state into a strict HTTP/1.1 byte payload.
        /// </summary>
        public byte[] ToBytes()
        {
            // TODO: 1. Initialize a StringBuilder.
            // TODO: 2. Append the Start Line: $"HTTP/1.1 {StatusCode} {StatusMessage}\r\n"
            // TODO: 3. Loop through the Headers dictionary and append: $"{Key}: {Value}\r\n"
            // TODO: 4. Append the mandatory empty line that separates headers from the body: "\r\n"
            // TODO: 5. Append the Body (if it is not empty).
            // TODO: 6. Convert the finalized string to UTF8 bytes and return.

            throw new System.NotImplementedException();
        }
    }
}
