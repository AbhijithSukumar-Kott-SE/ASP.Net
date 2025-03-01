
using ConnectExternalMedia;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectMedia.connectBluetooth();
        ConnectMedia.connectWifi("Psycho");
    }
}