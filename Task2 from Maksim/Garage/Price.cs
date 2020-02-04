namespace Garage
{
    /// <summary>
    /// Class contains prices for certain services.
    /// </summary>
    internal static class Price
    {
        /// <summary>
        /// Gets or Sets the cost of whell maintenance.
        /// </summary>
        public static double WheelMaintenance { get; set; }

        /// <summary>
        /// Gets or Sets the cost of transport wash.
        /// </summary>
        public static double TransportWash { get; set; }

        /// <summary>
        /// Gets or Sets the cost of oil change.
        /// </summary>
        public static double OilChange { get; set; }

        /// <summary>
        /// Gets or Sets the cost of fuel.
        /// </summary>
        public static double Fuel { get; set; }
    }
}
