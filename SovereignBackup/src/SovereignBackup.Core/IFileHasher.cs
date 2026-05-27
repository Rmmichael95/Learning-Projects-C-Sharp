using System.Threading.Tasks;

namespace SovereignBackup.Core
{
    /// <summary>
    /// Defines a contract for generating file hashes. Abstracting this allows us to
    /// write unit tests without actually reading gigabytes of data from a hard drive.
    /// </summary>
    public interface IFileHasher
    {
        /// <summary>
        /// Asynchronously computes a cryptographic hash (e.g., SHA-256) of a file's contents.
        /// </summary>
        Task<string> ComputeHashAsync(string filePath);
    }
}
