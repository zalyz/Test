using Garage.Interfeces;

namespace Garage.ClasesOfTransport
{
    /// <summary>
    /// Class describes ground transport.
    /// </summary>
    internal class Car : Transport, IComputable
    {
        private const int DefaultNumberOfCar = 1;

        /// <summary>
        /// Gets or Sets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; set; }

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = true;

        /// <inheritdoc/>
        public override int NumberForSearch { get; } = DefaultNumberOfCar;

        /// <inheritdoc/>
        public double MaintenanceCost()
        {
            int litersForOilChange = 2;
            double coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += this.NumberOfWheels * Price.WheelMaintenance;
            coastOfMaintenance += Price.TransportWash + (Price.OilChange * litersForOilChange);
            return coastOfMaintenance;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string transportInfo;
            transportInfo =
                $"Car №:   \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Wheels:  \t{this.NumberOfWheels}\n" +
                $"Service: \t{this.MaintenanceCost()}$";
            return transportInfo.ToString();
        }
    }
}
