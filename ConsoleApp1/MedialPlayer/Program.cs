
using ConnectExternalMedia;
using MedialPlayer;

internal class Program
{
    private static  async Task Main(string[] args)
    {
        ConnectMedia.connectBluetooth();  
        ConnectMedia.connectWifi("Psycho");

        var maruthi = new Car(24354267, VehicleType.CAR);
        maruthi.Drive();

        await zomataOrderPlacementAsync();

        IMeassageSevice messageSevice = new EmailService();

        Notification notification = new Notification(messageSevice);

        notification.NotifyUser("Order placed");
    }

    public static async Task zomataOrderPlacementAsync()
    {
        await Task.Delay(5000);

        var restaurant = new Restaurant();

        restaurant.orderPlaced += (string order) => { Console.WriteLine($"Order for {order} accepted"); };

        restaurant.placeOrder("Biriyani");


    }
}