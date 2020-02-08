﻿using Garage.Interfeces;

namespace Garage.ClasesOfTransport
{
    /// <summary>
    /// Class describes air transport.
    /// </summary>
    internal class Plane : Transport, IComputable
    {
        private const int DefaultNumberOfPlane = 3;

        /// <summary>
        /// Gets or Sets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; set; }

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = true;

        /// <inheritdoc/>
        public double GetMaintenanceCost()
        {
            var litersForOilChange = 20;
            var coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += (this.NumberOfWheels * Price.WheelMaintenance) + Price.TransportWash;
            coastOfMaintenance += Price.OilChange * litersForOilChange;
            return coastOfMaintenance;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var transportInfo =
                $"Plane №: \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Wheels:  \t{this.NumberOfWheels}\n" +
                $"Service: \t{this.GetMaintenanceCost()}$";
            return transportInfo;
        }
    }
}
