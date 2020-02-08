using Garage.Interfeces;

namespace Garage.ClasesOfTransport
{
    /// <summary>
    /// Class describes water transport.
    /// </summary>
    internal class Boat : Transport, IComputable
    {
        private const int DefaultNumberOfBoat = 2;

        private const int DefaultNumberOfBoatWheels = 0;

        /// <summary>
        /// Gets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; } = DefaultNumberOfBoatWheels;

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = false;

        /// <inheritdoc/>
        public double GetMaintenanceCost()
        {
            var litersForOilChange = 1;
            var coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += this.NumberOfWheels * Price.WheelMaintenance;
            coastOfMaintenance += Price.OilChange * litersForOilChange;
            return coastOfMaintenance;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var transportInfo =
                $"Boat №:  \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Service: \t{this.GetMaintenanceCost()}$";
            return transportInfo;
        }
    }
}
