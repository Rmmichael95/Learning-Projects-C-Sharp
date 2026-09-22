using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PortScanner.Core
{
    public class ScannerEngine
    {
        /// <summary>
        /// Attempts a TCP connection to a single port with a strict timeout.
        /// </summary>
        public async Task<ScanResult> CheckPortAsync(
            string ipAddress,
            int port,
            int timeoutMs = 1000
        )
        {
            var result = new ScanResult { Port = port };

            // TODO: 1. Instantiate a new TcpClient.
            // TODO: 2. Start the ConnectAsync() task.
            // TODO: 3. Use Task.WhenAny() to race the connection task against a Task.Delay(timeoutMs).
            // TODO: 4. If the delay wins, the port is filtered/closed. Set IsOpen = false.
            // TODO: 5. If ConnectAsync wins, the port is open! Set IsOpen = true.
            // TODO: 6. Wrap in a try/catch. If an exception fires (Connection Refused), it's closed.
            // TODO: 7. ALWAYS ensure the TcpClient is cleanly Disposed/Closed in a finally block.

            using TcpClient tcpClient = new();
            try
            {
                Task connectionTask = tcpClient.ConnectAsync(ipAddress, port);
                Task completedTask = await Task.WhenAny(connectionTask, Task.Delay(timeoutMs));
                if (completedTask == connectionTask && connectionTask.IsCompletedSuccessfully)
                {
                    result.IsOpen = true;
                }
                else
                {
                    result.IsOpen = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some connection problem");
            }
            return result;
        }
    }
}
