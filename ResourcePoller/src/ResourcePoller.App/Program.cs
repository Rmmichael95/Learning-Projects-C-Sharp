namespace ResourcePoller.App;

public static class Program
{
    public static async Task Main()
    {
        await PollerDaemon.DaemonResourcePrinter();
    }
}
