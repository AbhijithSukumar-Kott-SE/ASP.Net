using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedialPlayer
{
    abstract class Vehicle
    {
        public int vin;

        public VehicleType type;

        public Vehicle(int vin, VehicleType type)
        {
            this.vin = vin;
            this.type = type;
        }
    }

    enum VehicleType
    {
        CAR,
        TRUCK,
        MOTOR_CYCLE
    }
}
