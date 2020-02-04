using Garage.Interfeces;

namespace Garage.Clases
{
    /// <summary>
    /// Class describes water transport.
    /// </summary>
    public class Boat : Transport, IComputable
    {
        /// <summary>
        /// Gets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; } = 0;

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = false;

        /// <inheritdoc/>
        public override int NumberForSearch { get; } = 2;

        /// <inheritdoc/>
        public double MaintenanceCost()
        {
            double coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += this.NumberOfWheels * Price.WheelMaintenance;
            coastOfMaintenance += Price.OilChange;
            return coastOfMaintenance;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string transportInfo;
            transportInfo =
                $"Boat №:  \t{this.RegistrationNumber}\n" +
                $"Speed:   \t{this.MaxSpeed}(km/h)\n" +
                $"Fuel:    \t{this.FuelQuantity}/{this.MaxFuelQuantity}\n" +
                $"Service: \t{this.MaintenanceCost()}";
            return transportInfo.ToString();
        }
    }
}
