using Garage.Interfeces;

namespace Garage.Clases
{
    /// <summary>
    /// Class describes air transport.
    /// </summary>
    public class Plane : Transport, IComputable
    {
        /// <summary>
        /// Gets or Sets number of transport wheels.
        /// </summary>
        public new int NumberOfWheels { get; set; }

        /// <inheritdoc/>
        public override bool IsSoundSignal { get; } = true;

        /// <inheritdoc/>
        public override int NumberForSearch { get; } = 3;

        /// <inheritdoc/>
        public double MaintenanceCost()
        {
            double coastOfMaintenance = (this.MaxFuelQuantity - this.FuelQuantity) * Price.Fuel;
            coastOfMaintenance += (this.NumberOfWheels * Price.WheelMaintenance) + Price.TransportWash;
            coastOfMaintenance += Price.OilChange * 20;
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
                $"Service: \t{this.MaintenanceCost()}";
            return transportInfo.ToString();
        }
    }
}
