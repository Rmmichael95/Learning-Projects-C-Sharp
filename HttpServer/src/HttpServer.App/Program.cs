/using System;
using System.Threading.Tasks;
using HttpServer.Core;

namespace HttpServer.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Sovereign HTTP Server...");

            int port = 8080;

            // 1. Instantiate the specific routing rules
            IRouter router = new WebAppRouter();

            // 2. Inject the router into the network engine
            var engine = new ServerEngine(port, router);

            Console.WriteLine($"Listening on http://localhost:{port}");

            // 3. Start the infinite listening loop
            await engine.StartAsync();
        }
    }
}/ See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
