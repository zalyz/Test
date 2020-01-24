using System;
using System.Collections.Generic;
using System.Text;
using Garage.Interfeces;

namespace Garage.Transport
{
    class Plane : ITransport
    {
        public double MaxFuelQuantity { get; set; }

        public double FuelQuantity { get; set; }

        public int NumberOfWheels { get; set; }

        public string RegistrationNumber { get; set; }

        public bool SoundSignal { get { return true; } }

        public int NumberForSearchAndSort { get { return 3; } }

        public int MaxSpeed { get; set; }

        public double MaintenanceCost()
        {
            double coastOfMaintenance = ((this.MaxFuelQuantity - this.FuelQuantity) * Prise.Fuel) + (this.NumberOfWheels * Prise.WheelMaintenance) + Prise.TransportWash + Prise.OilChange * 20;
            return coastOfMaintenance;
        }

        public override string ToString()
        {
            StringBuilder transportInfo = new StringBuilder();
            transportInfo.Append(
                $"Plane №: \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Wheels:  \t{this.NumberOfWheels}\n" +
                $"Service: \t{this.MaintenanceCost()}$"
                );
            return transportInfo.ToString();
        }
    }
}
