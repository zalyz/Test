using System;
using System.Collections.Generic;
using System.Text;
using Garage.Interfeces;

namespace Garage.Transport
{
    class Boat : ITransport
    {
        public double MaxFuelQuantity { get; set; }

        public double FuelQuantity { get; set; }

        public int NumberOfWheels { get { return 0; } }

        public string RegistrationNumber { get; set; }

        public bool SoundSignal { get { return false; } }

        public int NumberForSearchAndSort { get { return 2; } }

        public int MaxSpeed { get; set; }

        public double MaintenanceCost()
        {
            double coastOfMaintenance = ((this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel) + (this.NumberOfWheels * Price.WheelMaintenance) + Price.OilChange;
            return coastOfMaintenance;
        }

        public override string ToString()
        {
            StringBuilder transportInfo = new StringBuilder();
            transportInfo.Append(
                $"Boat №:  \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Service: \t{this.MaintenanceCost()}$"
                );
            return transportInfo.ToString();
        }
    }
}
