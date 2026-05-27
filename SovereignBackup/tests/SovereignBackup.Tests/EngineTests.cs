using System.Threading.Tasks;
using SovereignBackup.Core;
using Xunit;

namespace SovereignBackup.Tests
{
    // A fake hasher for testing that doesn't actually touch the hard drive
    public class MockHasher : IFileHasher
    {
        public Task<string> ComputeHashAsync(string filePath)
        {
            // Simulate a matching hash for any file, proving the "Skip" logic works.
            return Task.FromResult("MOCK_HASH_12345");
        }
    }

    public class EngineTests
    {
        [Fact]
        public async Task Engine_Instantiates_WithInjectedHasher()
        {
            // Arrange
            IFileHasher mockHasher = new MockHasher();

            // Act
            var engine = new BackupEngine(mockHasher);

            // Assert
            Assert.NotNull(engine);
        }
    }
}
