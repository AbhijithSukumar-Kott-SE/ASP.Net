using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    class Car : Vehicle
    {
        public Car(int vin, VehicleType type) : base(vin, type)
        {
        }

        public void Drive()
        {
            Console.WriteLine($"{this.type} can be driven");
        }
    }
}
