# Project I: System Resource Poller

## Course Context

**Module:** Systems Programming & Operating System Interoperability
**Prerequisites:** Basic C# syntax, understanding of while-loops, introductory file I/O.

## Project Overview

The System Resource Poller is a continuously running, lightweight daemon designed to interface directly with the host operating system. Rather than relying on heavy, abstracted third-party diagnostic libraries, this tool reads telemetry directly from the kernel level (e.g., parsing the virtual `/proc/meminfo` and `/proc/stat` files on bare-metal Linux or Proxmox environments). It then formats and outputs this data to the console at a defined cadence.

## Learning Objectives

1. **Operating System Interoperability:** Understand how the kernel exposes hardware states as readable text streams.
2. **Asynchronous Execution:** Implement non-blocking `async/await` while-loops (`Task.Delay`) to maintain a continuous application lifecycle without monopolizing CPU threads.
3. **Data Hydration:** Translate raw system text into strongly-typed C# plain-old-CLR-objects (POCOs).

## Architectural Philosophy

This project enforces a strict separation between data extraction and data presentation. By isolating the `ProcfsParser` into a standalone class library, the system parsing logic remains entirely decoupled from the file system. This adheres to a sovereign, hand-coded architecture where the underlying logic can be tested in isolation, ensuring stability before deployment to a live server environment.

## Evaluation Strategy

The core library must be verified via automated unit tests. The test suite will inject static, mocked string outputs of Linux kernel telemetry into the parser to ensure accurate extraction of memory limits, CPU ticks, and storage blocks without requiring root execution privileges.

