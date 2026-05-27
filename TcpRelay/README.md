# Bridge II: TCP Message Relay

## Overview

A headless TCP server that maintains persistent connections with multiple concurrent clients, relaying text streams between them.

## Architectural Focus: State Management & Thread Safety

Unlike a port scanner that immediately closes a socket, a relay must keep streams alive. This project introduces the `ConcurrentDictionary` to safely manage an evolving list of connected users across multiple asynchronous threads. It teaches graceful error handling for dropped connections (`IOExceptions`) without crashing the master listening loop.

