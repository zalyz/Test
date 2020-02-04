using System;
using System.Collections.Generic;
using System.Linq;
using Garage.Clases;
using Garage.Interfeces;

namespace Garage
{

    /// <summary>
    /// At this class pogram is starts.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isExitFromMenu = false;
            bool isSuccessFullRead = false, isSuccessFullWrite = false;
            List<Transport> listOfTransport = new List<Transport>();
            SetDefaultPrise();

            while (!isExitFromMenu)
            {
                try
                {
                    ShowMenuItems();
                    TransportProcessing(ref isExitFromMenu, ref isSuccessFullRead, ref isSuccessFullWrite, listOfTransport);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
        }

        /// <summary>
        /// Contains the execution logic for each menu item.
        /// </summary>
        /// <param name="isExitFromMenu">Indicates whether the user wants to exit the menu or not.</param>
        /// <param name="isSuccessFullRead">Reflects the success of reading the file.</param>
        /// <param name="isSuccessFullWrite">Reflects the success of writing to the file.</param>
        /// <param name="listOfTransport">Contains information about transports.</param>
        private static void TransportProcessing(ref bool isExitFromMenu, ref bool isSuccessFullRead, ref bool isSuccessFullWrite, List<Transport> listOfTransport)
        {
            switch (EnterNumber())
            {
                case 1:
                    ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 1).ToList());
                    break;
                case 2:
                    ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 2).ToList());
                    break;
                case 3:
                    ShowTransportInfo(listOfTransport.Where(e => e.NumberForSearch == 3).ToList());
                    break;
                case 4:
                    ShowTransportInfo(listOfTransport.OrderBy(e => e.NumberForSearch).ToList());
                    break;
                case 5:
                    var maxTransportSpeed = listOfTransport.Max(e => e.MaxSpeed);
                    ShowTransportInfo(listOfTransport.Where(e => e.MaxSpeed == maxTransportSpeed).ToList());
                    break;
                case 6:
                    var minMaintenanceCost = listOfTransport.Min(e => ((IComputable)e).MaintenanceCost());
                    ShowTransportInfo(listOfTransport.Where(e => ((IComputable)e).MaintenanceCost() == minMaintenanceCost).ToList());
                    break;
                case 7:
                    ShowTransportInfo(listOfTransport.Where(e => e.IsSoundSignal == true).ToList());
                    break;
                case 8:
                    isSuccessFullRead = FileStream.IsReadFileTo(listOfTransport);
                    if (isSuccessFullRead)
                    {
                        ShowMessage("The file was read successfully.");
                    }

                    break;
                case 9:
                    isSuccessFullWrite = FileStream.IsSaveInFileFrom(listOfTransport);
                    if (isSuccessFullWrite)
                    {
                        ShowMessage("Information is recorded successfully.");
                    }

                    break;
                case 10:
                    isExitFromMenu = true;
                    break;
                default:
                    ShowMessage("There is no such menu item.");
                    break;
            }
        }

        /// <summary>
        /// Shows menu items for user.
        /// </summary>
        private static void ShowMenuItems()
        {
            Console.Clear();
            Console.WriteLine("1: Show Cars.");
            Console.WriteLine("2: Show Boats.");
            Console.WriteLine("3: Show Planes.");
            Console.WriteLine("4: Order list of transport.");
            Console.WriteLine("5: Show the fastest transport.");
            Console.WriteLine("6: Least expensive transport in service.");
            Console.WriteLine("7: Transports whith sound signal.");
            Console.WriteLine("8: Read information from file.");
            Console.WriteLine("9: Save information in file.");
            Console.WriteLine("10: Exit.");
        }

        /// <summary>
        /// Shows message whith pause.
        /// </summary>
        /// <param name="message">Message that sould be shown.</param>
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Output transport information to the console.
        /// </summary>
        /// <param name="listOfTransport">List whith transports.</param>
        private static void ShowTransportInfo(List<Transport> listOfTransport)
        {
            if (!listOfTransport.Any())
            {
                ShowMessage("NO any transport.");
            }
            else
            {
                Console.Clear();
                foreach (var item in listOfTransport)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------------");
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Checking for correct entry of the menu item number.
        /// </summary>
        /// <returns>Item number.</returns>
        private static int EnterNumber()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                return number;
            }
            catch
            {
                throw;
            }
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
