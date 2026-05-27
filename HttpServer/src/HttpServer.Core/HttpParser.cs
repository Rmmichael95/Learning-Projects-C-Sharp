using System;

namespace HttpServer.Core
{
    public static class HttpParser
    {
        /// <summary>
        /// Deconstructs a raw HTTP payload into an HttpRequest object.
        /// </summary>
        public static HttpRequest Parse(string rawRequest)
        {
            // TODO: 1. Guard clause: Throw an ArgumentException if string is null or whitespace.

            var request = new HttpRequest();

            // TODO: 2. Split the rawRequest by the standard HTTP line ending "\r\n".
            //          Hint: You might need to handle just "\n" for badly behaved clients.

            // TODO: 3. Parse the Start Line (Index 0).
            //          Split it by spaces. It should have 3 parts (Method, Path, Version).
            //          Assign these to the request object.

            // TODO: 4. Loop through the remaining lines to parse Headers.
            //          Stop looping when you hit an empty string (the delimiter).
            //          Split each header line by ": " and add to the request.Headers dictionary.

            // TODO: 5. Capture the Body.
            //          Everything after that empty delimiter line is the payload.

            return request;
        }
    }
}
