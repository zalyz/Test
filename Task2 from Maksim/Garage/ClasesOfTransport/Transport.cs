namespace Garage.ClasesOfTransport
{
    /// <summary>
    /// Class that describes the same characteristics of all transports.
    /// </summary>
    internal abstract class Transport
    {
        /// <summary>
        /// Gets or sets maximum speed of transport.
        /// </summary>
        public int MaxSpeed { get; set; }

        /// <summary>
        /// Gets or Sets maximum amount of transport fuel.
        /// </summary>
        public double MaxFuelQuantity { get; set; }

        /// <summary>
        /// Gets or Sets amount of trnasport fuel at that moment.
        /// </summary>
        public double FuelQuantity { get; set; }

        /// <summary>
        /// Gets or Sets number Of transport wheels.
        /// </summary>
        public int NumberOfWheels { get; set; }

        /// <summary>
        /// Gets or Sets registration number fo the vehicle.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets a value indicating whether the ability to send an sound signal.
        /// </summary>
        public abstract bool IsSoundSignal { get; }
    }
}
