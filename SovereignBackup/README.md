# Phase 2: Asynchronous Sovereign Backup Utility

## Course Context

**Module:** File System I/O, Cryptography, and Advanced Concurrency
**Prerequisites:** Mastery of basic async/await (Project 4: Port Scanner) and basic Interfaces (Project 3: Data Vault).

## Project Overview

A robust, terminal-based synchronization engine designed to securely mirror directory trees to a target location (e.g., a mounted TrueNAS dataset or external drive). Unlike basic copy scripts, this utility utilizes cryptographic hashing (SHA-256) to verify data integrity, copying only files that have been cryptographically altered, while skipping identical files to save bandwidth and I/O cycles.

## Learning Objectives

1. **Parallel Disk I/O:** Manage the heavy performance penalties of the file system by orchestrating parallel execution using `Task.WhenAll`, maximizing throughput on multi-core processors.
2. **Thread-Safe State:** Utilize `ConcurrentBag` to safely aggregate success and failure logs from dozens of asynchronous threads running simultaneously.
3. **Advanced Exception Handling:** Implement graceful degradation. The application must catch and log `UnauthorizedAccessException` (permission denied) and `IOException` (file locked by another process) on individual files without crashing the master directory traversal loop.

## Architectural Philosophy

File systems are inherently untestable because they require modifying the host machine's hard drive. By extracting the cryptographic logic into an `IFileHasher` interface, the `BackupEngine` becomes agnostic to the actual hashing algorithm. This enforces strict Dependency Injection principles, allowing the engine's logic to be verified in a unit testing sandbox using mock dependencies.

