using Garage.Interfeces;

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
        public override int NumberForSearch { get; } = DefaultNumberOfPlane;

        /// <inheritdoc/>
        public double MaintenanceCost()
        {
            int litersForOilChange = 20;
            double coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += (this.NumberOfWheels * Price.WheelMaintenance) + Price.TransportWash;
            coastOfMaintenance += Price.OilChange * litersForOilChange;
            return coastOfMaintenance;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string transportInfo;
            transportInfo =
                $"Plane №: \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Wheels:  \t{this.NumberOfWheels}\n" +
                $"Service: \t{this.MaintenanceCost()}$";
            return transportInfo.ToString();
        }
    }
}
