using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpRelay.Core
{
    public class RelayEngine
    {
        // Thread-safe dictionary to track who is currently connected.
        private readonly ConcurrentDictionary<Guid, ActiveConnection> _connections = new();
        private readonly int _port;

        public RelayEngine(int port)
        {
            _port = port;
        }

        public async Task StartListeningAsync()
        {
            // TODO: Start TcpListener. In the while loop, accept clients and spin off HandleClientAsync tasks.
            throw new NotImplementedException();
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            var connection = new ActiveConnection(client);
            _connections.TryAdd(connection.ConnectionId, connection);

            try
            {
                using var reader = new StreamReader(client.GetStream());
                string line;

                // TODO: Await reader.ReadLineAsync() continuously.
                // When a message is received, call BroadcastMessageAsync(line, connection.ConnectionId).
            }
            finally
            {
                // Clean up state when the user disconnects or the stream breaks.
                _connections.TryRemove(connection.ConnectionId, out _);
                client.Close();
            }
        }

        private async Task BroadcastMessageAsync(string message, Guid senderId)
        {
            // TODO: Loop through all _connections.
            // If the connection ID does NOT match the senderId, write the message to their stream.
            throw new NotImplementedException();
        }
    }
}
