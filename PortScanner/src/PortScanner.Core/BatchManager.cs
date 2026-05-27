using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner.Core
{
    /// <summary>
    /// Controls the flow of asynchronous tasks to prevent socket exhaustion.
    /// </summary>
    public class BatchManager
    {
        // TODO: Look up how 'SemaphoreSlim' works in C#. It acts as a bouncer
        // for your async tasks, only letting 'X' amount run concurrently.
    }
}
