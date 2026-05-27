using System;
using System.Linq;
using Xunit;
using TcpRelay.Core;

namespace TcpRelay.Tests
{
    public class TrackerTests
    {
        [Fact]
        public void GetAllExcept_ExcludesTheSender_ReturnsEveryoneElse()
        {
            // Arrange
            var tracker = new ConnectionTracker();
            
            // Note: We are cheating slightly here by passing 'null' for the TcpClient 
            // since our ActiveConnection model doesn't strictly need a live socket just to store an ID.
            var user1 = new ActiveConnection(null); 
            var user2 = new ActiveConnection(null);
            var user3 = new ActiveConnection(null);

            tracker.Add(user1);
            tracker.Add(user2);
            tracker.Add(user3);

            // Act: User 1 sends a message, so we need a list of everyone EXCEPT User 1
            var recipients = tracker.GetAllExcept(user1.ConnectionId).ToList();

            // Assert
            Assert.Equal(2, recipients.Count);
            Assert.Does
