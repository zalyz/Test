using System;
using System.Collections.Generic;
using System.Linq;
using Garage.ClasesOfTransport;

namespace Garage
{
    /// <summary>
    /// At this class pogram is starts.
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool isExitFromMenu = false;
            bool isSuccessFullRead = false, isSuccessFullWrite = false;
            List<Transport> listOfTransport = new List<Transport>();
            SetDefaultPrise();

            while (!isExitFromMenu)
            {
                try
                {
                    MenuProcessing.ShowMenuItems();
                    MenuProcessing.TransportProcessing(ref isExitFromMenu, ref isSuccessFullRead, ref isSuccessFullWrite, listOfTransport);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
        }

        /// <summary>
        /// Shows message whith pause.
        /// </summary>
        /// <param name="message">Message that sould be shown.</param>
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Sets default prises for calculating.
        /// </summary>
        private static void SetDefaultPrise()
        {
            double defaultFuelCost = 3, defaultOilChangeCost = 2, defaultTransportWashCost = 20, defaultWheelMaintenanceCost = 35;
            Price.Fuel = defaultFuelCost;
            Price.OilChange = defaultOilChangeCost;
            Price.TransportWash = defaultTransportWashCost;
            Price.WheelMaintenance = defaultWheelMaintenanceCost;
        }
    }
}
