using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SovereignBackup.Core
{
    public class Sha256FileHasher : IFileHasher
    {
        public async Task<string> ComputeHashAsync(string filePath)
        {
            // TODO: 1. Open the file asynchronously in ReadOnly mode using FileStream.
            // TODO: 2. Instantiate a SHA256 cryptographic provider.
            // TODO: 3. Compute the hash from the stream asynchronously.
            // TODO: 4. Convert the resulting byte array into a hex string and return it.
            throw new NotImplementedException();
        }
    }
}
