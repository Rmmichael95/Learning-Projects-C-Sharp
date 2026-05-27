# C# Systems Architecture Sequence

## Core Philosophy

This repository contains a progressive sequence of hand-coded C# projects. It eschews heavy frameworks (like ASP.NET Core or Entity Framework) in favor of the Base Class Library (`System.Net`, `System.IO`, `System.Threading`). The architecture is strictly "KISS" (Keep It Simple, Stupid) and emphasizes a sovereign, test-driven approach to understanding systems at the lowest level.

## The Curriculum Trajectory

### Phase 1: Procedural Logic & Text Processing (CIS 30A Equivalent)

1. **System Resource Poller:** Continuous loops and basic OS interoperability (`/proc` text parsing).
2. **Server Log Analyzer:** Complex string manipulation and basic data aggregation (Dictionaries).

### Phase 2: Abstraction, State, & Sockets (CIS 30B Equivalent)

3. **Structured Data Vault:** Interfaces, Dependency Injection (IoC), and JSON serialization.
4. **Local Port Scanner:** Basic asynchronous TCP sockets and concurrency limits (`Task.WhenAll`).
5. **Sovereign Backup Utility:** Heavy concurrent File I/O, hashing, and advanced exception handling.
6. **TCP Message Relay:** Persistent network streams, state management, and thread-safe collections (`ConcurrentDictionary`).

### Phase 3: Systems Engineering Capstone

7. **HTTP Server From Scratch:** Combining all previous knowledge—socket listening, text parsing, continuous state, and interface-driven routing—into a fully compliant HTTP/1.1 web server.

## Tooling

All core libraries are strictly decoupled from their execution environments. Unit testing is handled via xUnit, designed to be run rapidly via Neovim (`neotest-vstest`).

