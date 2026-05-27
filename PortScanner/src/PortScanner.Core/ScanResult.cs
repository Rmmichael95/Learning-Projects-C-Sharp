namespace PortScanner.Core
{
    public class ScanResult
    {
        public int Port { get; set; }
        public bool IsOpen { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
