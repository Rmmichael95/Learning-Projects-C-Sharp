using System;
using System.IO;
using System.Net.Sockets;

namespace TcpRelay.Core
{
    public class ActiveConnection
    {
        public Guid ConnectionId { get; } = Guid.NewGuid();
        public TcpClient Client { get; set; }
        public StreamWriter Writer { get; set; }

        public ActiveConnection(TcpClient client)
        {
            Client = client;
            Writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
        }
    }
}
