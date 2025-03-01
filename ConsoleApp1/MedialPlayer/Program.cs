
using ConnectExternalMedia;
using MedialPlayer;

internal class Program
{
    private static void Main(string[] args)
    {
        ConnectMedia.connectBluetooth();
        ConnectMedia.connectWifi("Psycho");

        var maruthi = new Car(24354267, VehicleType.CAR);
        maruthi.Drive();
    }
}