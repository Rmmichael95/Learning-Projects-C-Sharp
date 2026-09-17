using System;
using System.Collections.Generic;
using System.IO;
using LogAnalyzer.Core;

namespace LogAnalyzer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: 1. Validate that the user provided a file path in 'args[0]'.
            // TODO: 2. Verify the file actually exists on disk using File.Exists().
            // TODO: 3. Read the file line-by-line (consider using File.ReadLines() to avoid loading massive files entirely into RAM).
            // TODO: 4. Pass each line to LogParser.ParseLine(), collecting the valid LogEntry objects into a List.
            // TODO: 5. Pass the List to MetricsCalculator.
            // TODO: 6. Format the results and print a beautiful text-based dashboard to the console.

            Console.WriteLine("Log Analyzer CLI started.");

            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]) || !File.Exists(args[0]))
                throw new FileNotFoundException("File not found.");

            List<LogEntry> logs = [];
            foreach (var line in File.ReadLines(args[0]))
            {
                try
                {
                    logs.Add(LogParser.ParseLine(line));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid log found!");
                }
            }
            MetricsCalculator calc = new(logs);
            Console.WriteLine(
                $"\nValid Logs: {logs.Count}\nTop IP: {calc.GetTopIpAddresses(1)}\nSeccessful Connections: {calc.GetTotalRequestsByStatusCode(200)}\nTotal Bytes Sent: {calc.GetTotalBytesTransferred()}"
            );
        }
    }
}
