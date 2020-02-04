using Garage.Interfeces;

namespace Garage.Clases
{
    /// <summary>
    /// Class describes ground transport.
    /// </summary>
    public class Car : Transport, IComputable
    {
        /// <summary>
        /// Gets or Sets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; set; }

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = false;

        /// <inheritdoc/>
        public override int NumberForSearch { get; } = 1;

        /// <inheritdoc/>
        public double MaintenanceCost()
        {
            double coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += this.NumberOfWheels * Price.WheelMaintenance;
            coastOfMaintenance += Price.TransportWash + Price.OilChange;
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
                $"Service: \t{this.MaintenanceCost()}";
            return transportInfo.ToString();
        }
    }
}
