using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    class Restaurant
    {
        public delegate void orderPlaceHandler(String orderDetail);

        public event orderPlaceHandler? orderPlaced;

        public void placeOrder(String order)
        {
            Console.WriteLine($"Order recieved of {order}");
            orderPlaced?.Invoke(order);
        }
    }
}
