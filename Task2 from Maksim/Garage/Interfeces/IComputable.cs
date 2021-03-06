﻿namespace Garage.Interfeces
{
    /// <summary>
    /// Allow to compute maintanance cost.
    /// </summary>
    public interface IComputable
    {
        /// <summary>
        /// Computes the cost of maintenance.
        /// </summary>
        /// <returns>The cost of maintenance vehicle.</returns>
        public double MaintenanceCost();
    }
}