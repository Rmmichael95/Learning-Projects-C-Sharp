# Project II: Server Log Aggregation & Analysis

## Course Context

**Module:** Data Processing, Collections, & Text Manipulation
**Prerequisites:** Project I, intermediate string manipulation, C# Collections (`Dictionary`, `List`), LINQ.

## Project Overview

Modern web hosting environments—whether running CloudLinux, cPanel, or standalone Nginx—generate massive volumes of access logs. The Log Analyzer is a command-line interface (CLI) tool engineered to ingest these standard raw text files, parse the data using highly optimized string manipulation, and aggregate the results into human-readable metrics (e.g., top IP addresses, 404 error frequencies, bandwidth consumption).

## Learning Objectives

1. **Advanced Text Processing:** Utilize `ReadOnlySpan<char>`, standard string splitting, or Regular Expressions to accurately decompose complex, formatted strings.
2. **Data Aggregation (LINQ & Collections):** Master the use of Dictionaries to map and reduce large datasets efficiently, calculating statistical anomalies.
3. **Graceful Error Handling:** Design systems that can gracefully ignore or log malformed lines without crashing the entire execution pipeline.

## Architectural Philosophy

Complexity is the enemy of stability. This project embraces a KISS methodology by completely separating the file reading mechanism (the App layer) from the data processing mechanism (the Core layer). This pipeline design ensures that the mathematical aggregation (`MetricsCalculator`) does not care whether the data came from a 10MB text file, a multi-gigabyte data center log archive, or a hardcoded test string.

## Evaluation Strategy

Students will write xUnit tests validating the `LogParser` against a variety of standard and malformed log entries. The `MetricsCalculator` must be proven mathematically accurate by passing arrays of mocked `LogEntry` objects and asserting the correct statistical outputs.

