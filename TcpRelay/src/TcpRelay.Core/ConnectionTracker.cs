using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TcpRelay.Core
{
    /// <summary>
    /// Manages the thread-safe state of who is currently connected.
    /// Extracted from the network engine so it can be unit tested!
    /// </summary>
    public class ConnectionTracker
    {
        private readonly ConcurrentDictionary<Guid, ActiveConnection> _connections = new();

        public void Add(ActiveConnection connection) =>
            _connections.TryAdd(connection.ConnectionId, connection);

        public void Remove(Guid id) => _connections.TryRemove(id, out _);

        public IEnumerable<ActiveConnection> GetAllExcept(Guid excludedId)
        {
            // TODO: Use LINQ to return all connections EXCEPT the one matching excludedId
            throw new NotImplementedException();
        }
    }
}
