using System;
using System.IO;
using System.Threading.Tasks;

namespace SovereignBackup.Core
{
    public class BackupEngine
    {
        private readonly IFileHasher _hasher;

        // Dependency Injection: The engine demands a way to hash files, but doesn't
        // care if it is MD5, SHA-256, or a fake test hasher.
        public BackupEngine(IFileHasher hasher)
        {
            _hasher = hasher;
        }

        /// <summary>
        /// Recursively scans a source directory and synchronizes it to a destination.
        /// </summary>
        public async Task<SyncReport> RunBackupAsync(string sourceDirectory, string targetDirectory)
        {
            var report = new SyncReport();

            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException(
                    $"Source directory not found: {sourceDirectory}"
                );
            }

            // TODO: 1. Ensure the target directory exists (Create it if it doesn't).
            // TODO: 2. Get all file paths in the source directory (SearchOption.AllDirectories).
            // TODO: 3. Create a concurrent loop or use Task.WhenAll to process files in parallel.
            //          - For each file, determine its relative path and map it to the target directory.
            //          - Call ProcessSingleFileAsync(...) for each file.

            throw new NotImplementedException();
        }

        private async Task ProcessSingleFileAsync(
            string sourceFile,
            string targetFile,
            SyncReport report
        )
        {
            try
            {
                // TODO: 1. Check if targetFile already exists.
                //          If it DOES exist:
                //              - Await _hasher.ComputeHashAsync() for BOTH files.
                //              - If the hashes match, add to report.SkippedFiles and return.
                // TODO: 2. Ensure the parent directory of targetFile exists.
                // TODO: 3. Copy the file. (Consider using FileStream for async copying of large files).
                // TODO: 4. Add to report.CopiedFiles.
            }
            catch (UnauthorizedAccessException)
            {
                // Graceful degradation: Log the failure but do not crash the entire backup job.
                report.FailedFiles.Add(sourceFile);
            }
            catch (IOException)
            {
                // Handles "File in Use" errors
                report.FailedFiles.Add(sourceFile);
            }
        }
    }
}
