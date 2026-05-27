using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Core
{
    public class ServerEngine
    {
        private readonly int _port;
        private readonly IRouter _router; // The injected dependency
        private bool _isRunning;

        public ServerEngine(int port, IRouter router)
        {
            _port = port;
            _router = router;
        }

        public async Task StartAsync()
        {
            // TODO: 1. Initialize a TcpListener on IPAddress.Any and _port.
            // TODO: 2. Start the listener.
            // TODO: 3. Set _isRunning = true and begin the while(_isRunning) loop.
            // TODO: 4. Inside the loop, await listener.AcceptTcpClientAsync().
            // TODO: 5. Hand the accepted client off to HandleClientAsync() without awaiting it,
            //          so the loop can immediately accept the next connection.

            throw new NotImplementedException();
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            // Ensure resources are destroyed when the method exits
            using (client)
            using (var stream = client.GetStream())
            {
                try
                {
                    // TODO: 1. Allocate a byte buffer (e.g., 4096 bytes).
                    // TODO: 2. Await stream.ReadAsync() to pull network data into the buffer.
                    //          If read count is 0, the client disconnected; exit early.
                    // TODO: 3. Convert the populated buffer bytes into a UTF8 string.

                    // TODO: 4. Pass the string to HttpParser.Parse().
                    // TODO: 5. Pass the resulting HttpRequest to _router.Route().

                    // TODO: 6. Call ToBytes() on the resulting HttpResponse.
                    // TODO: 7. Await stream.WriteAsync() to send the bytes back to the client.
                }
                catch (Exception ex)
                {
                    // Catch malformed requests or dropped connections so they don't crash the server
                    Console.WriteLine($"Connection Error: {ex.Message}");
                }
            }
        }
    }
}
