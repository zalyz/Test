using System;
using System.Collections.Generic;
using System.Text;
using Garage.Transport;

namespace Garage.Interfeces
{
    /// <summary>
    /// Interface that describes the same characteristics of all transports.
    /// </summary>
    public interface ITransport
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
        /// Gets number Of transport wheels.
        /// </summary>
        public int NumberOfWheels { get; }

        /// <summary>
        /// Gets or Sets registration number fo the vehicle.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Gets 
        /// </summary>
        public bool SoundSignal { get; }

        /// <summary>
        /// Gets number that is used to search specific type of transport or sort by type of transport.
        /// </summary>
        public int NumberForSearchAndSort { get; }

        /// <summary>
        /// Computes the cost of maintenance.
        /// </summary>
        /// <returns>The cost of maintenance vehicle.</returns>
        public double MaintenanceCost();
    }
}