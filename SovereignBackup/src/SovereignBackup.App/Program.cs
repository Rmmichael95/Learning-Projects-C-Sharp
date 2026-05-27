/using System;
using System.Threading.Tasks;
using SovereignBackup.Core;

namespace SovereignBackup.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Initiating Sovereign Backup Utility...");

            // In a real CLI app, you would parse args[0] and args[1] here.
            string sourcePath = "/home/user/documents"; 
            string targetPath = "/mnt/truenas/backups/documents";

            // 1. Instantiate concrete dependencies
            IFileHasher hasher = new Sha256FileHasher();

            // 2. Inject dependency into the engine
            var backupEngine = new BackupEngine(hasher);

            try
            {
                // 3. Execute asynchronous run
                SyncReport report = await backupEngine.RunBackupAsync(sourcePath, targetPath);

                Console.WriteLine("\n--- Backup Complete ---");
                Console.WriteLine($"Files Copied:  {report.CopiedFiles.Count}");
                Console.WriteLine($"Files Skipped: {report.SkippedFiles.Count}");
                Console.WriteLine($"Errors:        {report.FailedFiles.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FATAL ERROR: {ex.Message}");
            }
        }
    }
}/ See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
