using System;
using System.Collections.Generic;
using System.Linq;
using DataVault.Core;
using Xunit;

namespace DataVault.Tests
{
    // 1. Create a fake repository purely for testing purposes
    public class MockRepository : IDataRepository
    {
        private readonly List<VaultRecord> _records = [];

        public void SaveRecord(VaultRecord record) => _records.Add(record);

        public VaultRecord GetRecord(Guid id) => _records.FirstOrDefault(r => r.Id == id);

        public IEnumerable<VaultRecord> GetAllRecords() => _records;

        public void DeleteRecord(Guid id) => _records.RemoveAll(r => r.Id == id);
    }

    public class EngineTests
    {
        [Fact]
        public void SearchByTitle_FindsCorrectRecords_IgnoringCase()
        {
            // Arrange: Feed the fake repository into the engine
            var mockRepo = new MockRepository();
            mockRepo.SaveRecord(new VaultRecord { Title = "Bank Password", Payload = "1234" });
            mockRepo.SaveRecord(new VaultRecord { Title = "SSH Key", Payload = "abcd" });

            var engine = new VaultEngine(mockRepo);

            // Act: Perform the search
            var results = engine.SearchByTitle("bank").ToList();

            // Assert: Verify the LINQ logic inside the engine works
            Assert.Single(results); // Should only find one
            Assert.Equal("1234", results[0].Payload);
        }
    }
}
