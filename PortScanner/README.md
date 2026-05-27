# Project III: Network I/O & Concurrency Management

## Course Context

**Module:** Network Fundamentals & Thread Safety
**Prerequisites:** Project I & II, foundational TCP/IP networking concepts.

## Project Overview

The Local Port Scanner bridges the gap between local system execution and remote network discovery. The application is designed to probe a target IP address across thousands of logical ports to identify active listeners. Because standard linear execution would take hours to scan 65,535 ports, this project requires the implementation of safe, throttled concurrency to scan in parallel without exhausting the host machine's socket pool.

## Learning Objectives

1. **Network Sockets:** Establish and handle TCP handshakes using the native `TcpClient` class.
2. **Concurrency & Synchronization:** Utilize `Task.WhenAll` and `SemaphoreSlim` (or similar batching logic) to manage thread pools and enforce strict execution limits.
3. **Timeout Management:** Implement race conditions (`Task.WhenAny`) to aggressively timeout dropped packets or filtered ports.

## Architectural Philosophy

A sovereign network tool must be precise and resource-efficient. If a tool spawns 60,000 uncontrolled threads, it becomes a localized Denial of Service attack. This architecture focuses heavily on the `BatchManager`—a dedicated orchestrator that governs the flow of operations. By separating the _execution_ of a scan from the _scheduling_ of a scan, the codebase remains modular, predictable, and highly scalable.

## Evaluation Strategy

The evaluation focuses heavily on thread safety and timeout logic. Automated tests will verify that the `BatchManager` successfully limits the number of actively running tasks to the configured maximum, and that network connection attempts cleanly abort and dispose of resources when a timeout threshold is exceeded.

