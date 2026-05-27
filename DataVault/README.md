# Bridge I: Structured Data Vault

## Overview

A terminal-based secure storage utility. This project shifts the focus from reading unstructured text to managing structured, persistent state using JSON serialization and Language Integrated Query (LINQ).

## Architectural Focus: Dependency Injection

This project introduces the Repository Pattern. The core logic (`VaultEngine`) is strictly separated from the storage mechanism via the `IDataRepository` interface. This allows the application to dynamically swap between an in-memory testing database and a persistent JSON file structure on disk without rewriting the core engine.

